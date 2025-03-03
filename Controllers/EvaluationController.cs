using InvoiceEvaluationAPI.Models;
using InvoiceEvaluationAPI.Services;
using InvoiceEvaluationAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly ILogger<EvaluationController> _logger;
        private readonly IInvoiceValidator _validator;
        private readonly IThirdPartyApiService _thirdPartyApiService;
        private readonly IRuleEngineService _ruleEngineService;
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(
            ILogger<EvaluationController> logger,
            IInvoiceValidator validator,
            IThirdPartyApiService thirdPartyApiService,
            IRuleEngineService ruleEngineService,
            IEvaluationService evaluationService)
        {
            _logger = logger;
            _validator = validator;
            _thirdPartyApiService = thirdPartyApiService;
            _ruleEngineService = ruleEngineService;
            _evaluationService = evaluationService;
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> Evaluate([FromForm] InvoiceRequest request)
        {
            
            try
            {
                _logger.LogInformation("Received invoice evaluation request for invoice {InvoiceId}", 
                    request?.InvoiceDetails?.InvoiceId ?? "unknown");

                // Step 1: Validate the request
                if (request == null)
                {
                    _logger.LogWarning("Invoice request is null.");
                    return BadRequest("Invalid request: Request cannot be null.");
                }

                var validationResult = await _validator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Invoice validation failed: {ErrorMessage}", validationResult.ErrorMessage);
                    return BadRequest(validationResult.ErrorMessage);
                }

                // Step 2: Get document bytes for third-party API
                byte[] documentBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await request.InvoiceDocument.CopyToAsync(memoryStream);
                    documentBytes = memoryStream.ToArray();
                }

                // Step 3: Get classification from third-party API
                var classification = await _thirdPartyApiService.GetInvoiceClassificationAsync(documentBytes);
                _logger.LogInformation("Invoice classified as {Classification} with risk level {RiskLevel}", 
                    classification.Classification, classification.RiskLevel);

                // Step 4: Apply decision rules
                var appliedRules = await _ruleEngineService.EvaluateRulesAsync(request.InvoiceDetails, classification);
                _logger.LogInformation("Applied {RuleCount} rules to invoice", appliedRules.Count);

                // Step 5: Generate evaluation summary
                var evaluationSummary = await _evaluationService.GenerateEvaluationSummaryAsync(
                    request.InvoiceDetails, 
                    classification, 
                    appliedRules);

                _logger.LogInformation("Generated evaluation summary with ID {EvaluationId}", 
                    evaluationSummary.EvaluationId);

                return Ok(evaluationSummary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing invoice evaluation request");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}