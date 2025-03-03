namespace InvoiceEvaluationAPI.Models
{
    public class Rule
    {
        public required string RuleId { get; set; }
        public required string Condition { get; set; }
        public required string Action { get; set; }
    }
}