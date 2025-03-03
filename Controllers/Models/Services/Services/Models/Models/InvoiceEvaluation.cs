using System.Collections.Generic;

namespace InvoiceEvaluationAPI.Models
{
    public class InvoiceEvaluation
    {
        public required ThirdPartyApiResponse Classification { get; set; }
        public required InvoiceDetails InvoiceDetails { get; set; }
        public List<string> AppliedRules { get; set; } = new List<string>();
    }
}