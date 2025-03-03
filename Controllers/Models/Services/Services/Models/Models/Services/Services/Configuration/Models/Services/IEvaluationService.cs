using InvoiceEvaluationAPI.Models;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public interface IEvaluationService
    {
        Task<EvaluationSummary> GenerateEvaluationSummaryAsync(
            InvoiceDetails invoiceDetails, 
            ThirdPartyApiResponse classification, 
            List<string> appliedRules);
    }
}