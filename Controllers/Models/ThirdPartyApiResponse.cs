namespace InvoiceEvaluationAPI.Models
{
    public class ThirdPartyApiResponse
    {
        public required string Classification { get; set; }
        public required string RiskLevel { get; set; }
    }
}