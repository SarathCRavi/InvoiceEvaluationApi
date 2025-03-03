using InvoiceEvaluationAPI.Models;
using InvoiceEvaluationAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Tests
{
    [TestFixture]
    public class RuleEngineServiceTests
    {
        private Mock<ILogger<RuleEngineService>> _loggerMock = null!;
        private RuleEngineService _ruleEngineService = null!;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<RuleEngineService>>();
            _ruleEngineService = new RuleEngineService(_loggerMock.Object);
        }

        [Test]
        public async Task EvaluateRulesAsync_LowRiskAndLowAmount_ReturnsApprove()
        {
            // Arrange
            var invoiceDetails = new InvoiceDetails
            {
                InvoiceId = "12345",
                InvoiceNumber = "S12345",
                InvoiceDate = DateTime.Now,
                Comment = "Test invoice",
                Amount = 500 // Less than 1000
            };

            var classification = new ThirdPartyApiResponse
            {
                Classification = "WaterLeakDetection",
                RiskLevel = "Low"
            };

            // Act
            var result = await _ruleEngineService.EvaluateRulesAsync(invoiceDetails, classification);

            // Assert
            Assert.Contains("Approve", result);
        }

        [Test]
        public async Task EvaluateRulesAsync_HighRiskFireDamage_ReturnsFlagForReview()
        {
            // Arrange
            var invoiceDetails = new InvoiceDetails
            {
                InvoiceId = "12345",
                InvoiceNumber = "S12345",
                Comment = "Test invoice",
                InvoiceDate = DateTime.Now,
                Amount = 2000
            };

            var classification = new ThirdPartyApiResponse
            {
                Classification = "FireDamagedWallRepair",
                RiskLevel = "High"
            };

            // Act
            var result = await _ruleEngineService.EvaluateRulesAsync(invoiceDetails, classification);

            // Assert
            Assert.Contains("Flag for Review", result);
        }
    }
}