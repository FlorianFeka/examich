using ExamichService.Configuration.Dependency;
using ExamichService.Entity;
using ExamichService.Entity.Seed;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ExamichService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get;  }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(Configuration["CorsHosts"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExamichService", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddRepositoryConfig();

            services.AddTransient<Seed>();

            services.AddDbContextPool<ExamichServiceDbContext>(
                //opt => opt.UseInMemoryDatabase(databaseName: "examich"));
                //opt => opt.UseSqlServer(Configuration["ConnectionStrings:ExamichServiceDb"]));
                opt =>
                {
                    opt.UseSqlServer(Configuration["ConnectionStrings:ExamichServiceDb"]);
                    if (!Environment.IsProduction())
                    {
                        opt.EnableSensitiveDataLogging();
                    }
                });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme, 
                opt =>
                {
                    /*if (!Environment.IsProduction())
                    {
                        opt.TokenValidationParameters.ValidateActor = false;
                        opt.TokenValidationParameters.ValidateAudience = false;
                        opt.TokenValidationParameters.ValidateIssuer = false;
                        opt.TokenValidationParameters.ValidateLifetime = false;
                        opt.TokenValidationParameters.ValidateTokenReplay = false;
                        opt.TokenValidationParameters.ValidateIssuerSigningKey = false;
                        opt.SecurityTokenValidators.Clear();
                    }*/
                    Configuration.Bind("JwtSettings", opt);
                    opt.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["IssuerSigningKey"]));
                });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(ExamichService.Configuration.Base)));

            services.AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<ExamichService.Configuration.Base>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed seed)
        {
            // if (!env.IsProduction())
            // {
                seed.Init();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamichService v1"));
            // }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
