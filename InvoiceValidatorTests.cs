using InvoiceEvaluationAPI.Models;
using InvoiceEvaluationAPI.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Tests
{
    [TestFixture]
    public class InvoiceValidatorTests
    {
        private Mock<ILogger<InvoiceValidator>> _loggerMock= null!;
        private InvoiceValidator _validator = null!;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<InvoiceValidator>>();
            _validator = new InvoiceValidator(_loggerMock.Object);
        }

        [Test]
        public async Task ValidateAsync_ValidRequest_ReturnsValidResult()
        {
            // Arrange
            var request = new InvoiceRequest
            {
                InvoiceDocument = CreateMockPdfFile(),
                InvoiceDetails = new InvoiceDetails
                {
                    InvoiceId = "12345",
                    InvoiceNumber = "S12345",
                    InvoiceDate = DateTime.Now,
                    Comment = "Test invoice",
                    Amount = 850
                }
            };

            // Act
            var result = await _validator.ValidateAsync(request);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.IsNull(result.ErrorMessage);
        }

        [Test]
        public async Task ValidateAsync_InvalidInvoiceNumber_ReturnsInvalidResult()
        {
            // Arrange
            var request = new InvoiceRequest
            {
                InvoiceDocument = CreateMockPdfFile(),
                InvoiceDetails = new InvoiceDetails
                {
                    InvoiceId = "12345",
                    InvoiceNumber = "123456", // Invalid format, should start with 'S'
                    InvoiceDate = DateTime.Now,
                    Comment = "Test comment",
                    Amount = 1000
                }
            };

            // Act
            var result = await _validator.ValidateAsync(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.ErrorMessage.Contains("Invoice number must start with 'S'"));
        }

        private IFormFile CreateMockPdfFile()
        {
            // Create a mock PDF file
            var content = Encoding.UTF8.GetBytes("%PDF-1.5 mock PDF content");
            var fileName = "InvoiceDocument.pdf";
            var stream = new MemoryStream(content);

            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(content.Length);
            fileMock.Setup(f => f.ContentType).Returns("application/pdf");
            fileMock.Setup(f => f.OpenReadStream()).Returns(stream);
            fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<System.Threading.CancellationToken>()))
                .Callback<Stream, System.Threading.CancellationToken>((stream, token) =>
                {
                    new MemoryStream(content).CopyTo(stream);
                })
                .Returns(Task.CompletedTask);

            return fileMock.Object;
        }
    }
}