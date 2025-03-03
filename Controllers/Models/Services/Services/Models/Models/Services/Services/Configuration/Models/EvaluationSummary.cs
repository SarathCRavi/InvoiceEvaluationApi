using System.Collections.Generic;

namespace InvoiceEvaluationAPI.Models
{
    public class EvaluationSummary
    {
        public required string EvaluationId { get; set; }
        public required string InvoiceId { get; set; }
        public List<string> RulesApplied { get; set; } = new List<string>();
        public required string Classification { get; set; }
        public required string EvaluationFile { get; set; } // Base64 encoded string
    }
}