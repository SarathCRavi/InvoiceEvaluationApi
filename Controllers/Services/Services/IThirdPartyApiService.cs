using InvoiceEvaluationAPI.Models;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public interface IThirdPartyApiService
    {
        Task<ThirdPartyApiResponse> GetInvoiceClassificationAsync(byte[] documentData);
    }
}