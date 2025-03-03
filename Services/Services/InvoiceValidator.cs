using InvoiceEvaluationAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Validators
{
    public class InvoiceValidator : IInvoiceValidator
    {
        private readonly ILogger<InvoiceValidator> _logger;
        private const int MaxFileSizeInMb = 10;
        private const string InvoiceNumberPattern = @"^S\d{5}$";

        public InvoiceValidator(ILogger<InvoiceValidator> logger)
        {
            _logger = logger;
        }

        public Task<ValidationResult> ValidateAsync(InvoiceRequest request)
        {
            _logger.LogInformation("Validating invoice request");
            
            if (request == null)
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Request cannot be null" 
                });
            }

            if (request.InvoiceDocument == null || request.InvoiceDocument.Length == 0)
            {
                return Task.FromResult(new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Invoice document is required"
                });
            }

            if (request.InvoiceDetails == null)
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Invoice details are required" 
                });
            }

            // Validate file size
            if (request.InvoiceDocument.Length > MaxFileSizeInMb * 1024 * 1024)
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = $"Invoice document size exceeds the maximum allowed size of {MaxFileSizeInMb}MB" 
                });
            }

            // Validate file type (PDF)
            if (!request.InvoiceDocument.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Only PDF files are accepted" 
                });
            }

            // Validate invoice details
            if (string.IsNullOrWhiteSpace(request.InvoiceDetails.InvoiceId))
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Invoice ID is required" 
                });
            }

            if (string.IsNullOrWhiteSpace(request.InvoiceDetails.InvoiceNumber))
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Invoice number is required" 
                });
            }

            // Validate invoice number format (S followed by 5 digits)
            if (!Regex.IsMatch(request.InvoiceDetails.InvoiceNumber, InvoiceNumberPattern))
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Invoice number must start with 'S' followed by 5 digits" 
                });
            }

            if (request.InvoiceDetails.Amount <= 0)
            {
                return Task.FromResult(new ValidationResult 
                { 
                    IsValid = false, 
                    ErrorMessage = "Amount must be greater than zero" 
                });
            }

            return Task.FromResult(new ValidationResult { IsValid = true });
        }
    }
}