using InvoiceEvaluationAPI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public class ThirdPartyApiService : IThirdPartyApiService
    {
        private readonly ILogger<ThirdPartyApiService> _logger;
        //private readonly string _apiUrl = "https://mocki.io/v1/c88b98d3-57b3-4cf1-8634-4df4db0ae616"; // Mock API URL
        //private readonly string _apiUrl = "https://mocki.io/v1/95d68f1f-6b11-4890-982e-18725f3d4512"; // New Working URL
        //private readonly string _apiUrl = "https://mocki.io/v1/95d68f1f-6b11-4890-982e-18725f3d4512"; 
        
        private readonly string _apiUrl = "https://invoiceevaluationapi.free.beeceptor.com";
        

        private readonly AsyncRetryPolicy _retryPolicy;

        public ThirdPartyApiService(ILogger<ThirdPartyApiService> logger)
        {
            _logger = logger;
            
            // Define a retry policy with exponential backoff
            _retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    3, // Number of retries
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Exponential backoff
                    (exception, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning(exception, 
                            "Error calling third-party API (Attempt {RetryCount}). Retrying in {RetryTimeSpan}...", 
                            retryCount, timeSpan);
                    }
                );
        }

        public async Task<ThirdPartyApiResponse> GetInvoiceClassificationAsync(byte[] documentData)
        {
            _logger.LogInformation("Getting invoice classification from third-party API");

            // For this mock implementation, we'll return a hard-coded response
            
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                var options = new RestClientOptions(_apiUrl);
                var client = new RestClient(options);
                //var client = new RestClient("https://mocki.io/v1/95d68f1f-6b11-4890-982e-18725f3d4512/api/invoice-classify");

                //var request = new RestRequest();
                //var request = new RestRequest
                //{
                    //Method = Method.Post
                //};
                //var request = new RestRequest(Method.Post);
                var request = new RestRequest();
                request.Method = Method.Post;

                request.AddFile("InvoiceDocument", documentData, "InvoiceDocument.pdf", "application/pdf");

                request.AddHeader("Accept", "application/json");
                //request.AddHeader("Content-Type", "multipart/form-data");

                //request.AddHeader("Accept", "application/json");
                //request.AddParameter("application/json", documentData, ParameterType.RequestBody);

                //string json = JsonConvert.SerializeObject(new { Document = Convert.ToBase64String(documentData) });
                //request.AddJsonBody(json);

                //var json = JsonConvert.SerializeObject(new { Document = Convert.ToBase64String(documentData) });
                //request.AddStringBody(json, DataFormat.Json);

                //var response = await client.ExecuteGetAsync(request);
                //var response = await client.PostAsync(request);
                var response = await client.ExecuteAsync(request);
                               
                
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError("Third-party API returned status code {StatusCode}", response.StatusCode);
                    throw new Exception($"Third-party API returned status code {response.StatusCode}");
                }
 
                // Check for null/empty content
                if (string.IsNullOrEmpty(response.Content))
                {
                    _logger.LogError("Third-party API returned empty/null content");
                    throw new Exception("Third-party API returned invalid response");
                }

                // Deserialize and handle possible null
                var result = JsonConvert.DeserializeObject<ThirdPartyApiResponse>(response.Content);
                if (result == null)
                {
                    _logger.LogError("Failed to deserialize third-party API response");
                    throw new Exception("Invalid third-party API response");
                }

                return result;
            });
        }
    }
}