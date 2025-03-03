using InvoiceEvaluationAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InvoiceEvaluationAPI.Tests
{
    [TestFixture]
    public class EvaluationControllerIntegrationTests
    {
        private WebApplicationFactory<Program> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task Evaluate_ValidRequest_ReturnsSuccessResult()
        {
            // Arrange
            var fileName = "InvoiceDocument.pdf";
            var fileContent = "%PDF-1.5 mock PDF content";
            var pdfBytes = System.Text.Encoding.UTF8.GetBytes(fileContent);

            using var content = new MultipartFormDataContent();
            
            // Add the PDF file
            var fileContent1 = new ByteArrayContent(pdfBytes);
            fileContent1.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
            content.Add(fileContent1, "InvoiceDocument", fileName);
            
            // Add the invoice details
            content.Add(new StringContent("12345"), "InvoiceDetails.InvoiceId");
            content.Add(new StringContent("S12345"), "InvoiceDetails.InvoiceNumber");
            content.Add(new StringContent(DateTime.Now.ToString("o")), "InvoiceDetails.InvoiceDate");
            content.Add(new StringContent("Test comment"), "InvoiceDetails.Comment");
            content.Add(new StringContent("850.00"), "InvoiceDetails.Amount");

            // Act
            var response = await _client.PostAsync("/api/Evaluation/evaluate", content);
            var responseString = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(responseString);
            
            var evaluationSummary = JsonConvert.DeserializeObject<EvaluationSummary>(responseString);
            Assert.IsNotNull(evaluationSummary);
            Assert.IsNotNull(evaluationSummary!.EvaluationId);
            Assert.AreEqual("12345", evaluationSummary.InvoiceId);
            Assert.IsNotNull(evaluationSummary.Classification);
            Assert.IsNotNull(evaluationSummary.EvaluationFile);
        }
    }
}