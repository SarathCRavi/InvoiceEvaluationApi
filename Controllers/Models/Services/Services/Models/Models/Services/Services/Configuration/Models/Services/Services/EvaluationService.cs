using InvoiceEvaluationAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly ILogger<EvaluationService> _logger;

        public EvaluationService(ILogger<EvaluationService> logger)
        {
            _logger = logger;
        }

        public Task<EvaluationSummary> GenerateEvaluationSummaryAsync(
            InvoiceDetails invoiceDetails, 
            ThirdPartyApiResponse classification, 
            List<string> appliedRules)
        {
            _logger.LogInformation("Generating evaluation summary for invoice {InvoiceId}", invoiceDetails.InvoiceId);
            
            // Generate unique evaluation ID
            string evaluationId = $"EVAL{DateTime.UtcNow:yyMMddHHmmss}";
            
            // Generate plain text summary
            string plainTextSummary = GeneratePlainTextSummary(invoiceDetails, classification, appliedRules);
            
            // Convert to Base64
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainTextSummary);
            string base64String = Convert.ToBase64String(plainTextBytes);
            
            var summary = new EvaluationSummary
            {
                EvaluationId = evaluationId,
                InvoiceId = invoiceDetails.InvoiceId,
                RulesApplied = appliedRules,
                Classification = classification.Classification,
                EvaluationFile = base64String
            };
            
            return Task.FromResult(summary);
        }

        private string GeneratePlainTextSummary(
            InvoiceDetails invoiceDetails, 
            ThirdPartyApiResponse classification, 
            List<string> appliedRules)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine("Invoice Evaluation Summary");
            sb.AppendLine("=========================");
            sb.AppendLine();
            sb.AppendLine($"Date: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
            sb.AppendLine();
            sb.AppendLine("Invoice Information:");
            sb.AppendLine($"- Invoice ID: {invoiceDetails.InvoiceId}");
            sb.AppendLine($"- Invoice Number: {invoiceDetails.InvoiceNumber}");
            sb.AppendLine($"- Invoice Date: {invoiceDetails.InvoiceDate:yyyy-MM-dd}");
            sb.AppendLine($"- Amount: ${invoiceDetails.Amount:N2}");
            
            if (!string.IsNullOrEmpty(invoiceDetails.Comment))
            {
                sb.AppendLine($"- Comment: {invoiceDetails.Comment}");
            }
            
            sb.AppendLine();
            sb.AppendLine("Classification:");
            sb.AppendLine($"- Type: {classification.Classification}");
            sb.AppendLine($"- Risk Level: {classification.RiskLevel}");
            sb.AppendLine();
            
            sb.AppendLine("Rules Applied:");
            if (appliedRules.Count > 0)
            {
                foreach (var rule in appliedRules)
                {
                    sb.AppendLine($"- {rule}");
                }
            }
            else
            {
                sb.AppendLine("- No rules matched");
            }
            
            sb.AppendLine();
            sb.AppendLine("Evaluation Result:");
            
            if (appliedRules.Contains("Approve"))
            {
                sb.AppendLine("This invoice has been APPROVED automatically based on the amount and risk level.");
            }
            else if (appliedRules.Contains("Flag for Review"))
            {
                sb.AppendLine("This invoice has been FLAGGED FOR REVIEW due to high risk factors.");
                sb.AppendLine("A claims adjuster should review this invoice before proceeding.");
            }
            else if (appliedRules.Contains("Manager Approval Required"))
            {
                sb.AppendLine("This invoice requires MANAGER APPROVAL due to the high amount.");
                sb.AppendLine("Please forward to the appropriate manager for review.");
            }
            else if (appliedRules.Contains("Fast Track"))
            {
                sb.AppendLine("This invoice has been marked for FAST TRACK processing.");
                sb.AppendLine("It should be processed within 24 hours.");
            }
            else
            {
                sb.AppendLine("This invoice requires standard processing.");
                sb.AppendLine("No special rules were triggered.");
            }
            
            sb.AppendLine();
            sb.AppendLine("This evaluation was generated automatically by the Invoice Evaluation System.");
            
            return sb.ToString();
        }
    }
}