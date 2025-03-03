using InvoiceEvaluationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public interface IRuleEngineService
    {
        Task<List<string>> EvaluateRulesAsync(InvoiceDetails invoiceDetails, ThirdPartyApiResponse classification);
        Task<List<Rule>> GetRulesAsync();
    }
}