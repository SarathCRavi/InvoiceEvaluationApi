using InvoiceEvaluationAPI.Models;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Validators
{
    public interface IInvoiceValidator
    {
        Task<ValidationResult> ValidateAsync(InvoiceRequest request);
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}