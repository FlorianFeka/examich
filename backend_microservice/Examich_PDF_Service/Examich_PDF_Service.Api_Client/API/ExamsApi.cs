using System;
using System.Threading.Tasks;
using Examich_PDF_Service.DTO.Exam;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;

namespace Examich_PDF_Service.Api_Client.API
{
    public class ExamsApi : IExamsApi
    {
        private readonly RestClient _client;
        private readonly ILogger<ExamsApi> _logger;
        public ExamsApi(IConfiguration configuration, ILogger<ExamsApi> logger)
        {
            var basePath = configuration["ExamServiceUrl"];
            _client = new RestClient($"http://{basePath}");
            _logger = logger;
        }
        
        public Task<GetExamDto> GetExamByIdAsync(Guid examId, string bearerToken)
        {
            _client.Authenticator = new JwtAuthenticator(bearerToken);
            _logger.Log(LogLevel.Debug, bearerToken);
            _logger.Log(LogLevel.Debug, $"/api/Exams/{examId}/Complete");
            var request = new RestRequest($"/api/Exams/{examId}/Complete");
            return _client.GetAsync<GetExamDto>(request);
        }
    }
}