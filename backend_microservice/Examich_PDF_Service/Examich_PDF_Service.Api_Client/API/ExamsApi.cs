using System;
using System.Threading.Tasks;
using Examich_PDF_Service.DTO.Exam;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Examich_PDF_Service.Api_Client.API
{
    public class ExamsApi : IExamsApi
    {
        private readonly RestClient _client;

        public ExamsApi(IConfiguration configuration)
        {
            var basePath = configuration["ExamServiceUrl"];
            _client = new RestClient($"http://{basePath}");
        }
        
        public Task<GetExamDto> GetExamByIdAsync(Guid examId, string bearerToken)
        {
            _client.Authenticator = new JwtAuthenticator(bearerToken);
            var request = new RestRequest($"/api/Exams/{examId}/Complete");
            return _client.GetAsync<GetExamDto>(request);
        }
    }
}