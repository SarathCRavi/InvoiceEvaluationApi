using InvoiceEvaluationAPI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceEvaluationAPI.Services
{
    public class RuleEngineService : IRuleEngineService
    {
        private readonly ILogger<RuleEngineService> _logger;
        private readonly string _rulesFilePath = "Configuration/rules.json";

        public RuleEngineService(ILogger<RuleEngineService> logger)
        {
            _logger = logger;
            
            // Ensure rules file exists
            if (!File.Exists(_rulesFilePath))
            {
                // Create the directory if it doesn't exist
               var directory = Path.GetDirectoryName(_rulesFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }


                // Create default rules
                var defaultRules = new List<Rule>
                {
                    new Rule { RuleId = "1", Condition = "amount < 1000 AND riskLevel == 'Low'", Action = "Approve" },
                    new Rule { RuleId = "2", Condition = "classification == 'FireDamagedWallRepair' AND riskLevel == 'High'", Action = "Flag for Review" },
                    new Rule { RuleId = "3", Condition = "amount > 5000", Action = "Manager Approval Required" },
                    new Rule { RuleId = "4", Condition = "classification == 'WaterLeakDetection' AND amount < 2000", Action = "Fast Track" }
                };
                
                File.WriteAllText(_rulesFilePath, JsonConvert.SerializeObject(defaultRules, Formatting.Indented));
            }
        }

        public async Task<List<Rule>> GetRulesAsync()
        {
            _logger.LogInformation("Loading rules from file");
            
            var rulesJson = await File.ReadAllTextAsync(_rulesFilePath);
            return JsonConvert.DeserializeObject<List<Rule>>(rulesJson) ?? new List<Rule>();

        }

        public async Task<List<string>> EvaluateRulesAsync(InvoiceDetails invoiceDetails, ThirdPartyApiResponse classification)
        {
            _logger.LogInformation("Evaluating rules for invoice {InvoiceId}", invoiceDetails.InvoiceId);
            
            var rules = await GetRulesAsync();
            var appliedActions = new List<string>();

            foreach (var rule in rules)
            {
                bool conditionMet = EvaluateCondition(rule.Condition, invoiceDetails, classification);
                
                if (conditionMet)
                {
                    _logger.LogInformation("Rule {RuleId} matched. Action: {Action}", rule.RuleId, rule.Action);
                    appliedActions.Add(rule.Action);
                }
            }

            return appliedActions;
        }

        private bool EvaluateCondition(string condition, InvoiceDetails invoiceDetails, ThirdPartyApiResponse classification)
        {
            try
            {
                // This is a simplified rule evaluation
                // In a real system, you might use a proper expression evaluator

                // Replace variables with actual values
                string evaluatableCondition = condition
                    .Replace("amount", invoiceDetails.Amount.ToString())
                    .Replace("classification", $"'{classification.Classification}'")
                    .Replace("riskLevel", $"'{classification.RiskLevel}'");
                
                // Parse AND conditions
                var conditions = evaluatableCondition.Split(new[] { "AND" }, StringSplitOptions.None);
                bool result = true;
                
                foreach (var cond in conditions)
                {
                    string trimmedCond = cond.Trim();
                    
                    if (trimmedCond.Contains("<"))
                    {
                        var parts = trimmedCond.Split('<');
                        decimal leftValue = decimal.Parse(parts[0].Trim());
                        decimal rightValue = decimal.Parse(parts[1].Trim());
                        if (!(leftValue < rightValue))
                        {
                            result = false;
                            break;
                        }
                    }
                    else if (trimmedCond.Contains(">"))
                    {
                        var parts = trimmedCond.Split('>');
                        decimal leftValue = decimal.Parse(parts[0].Trim());
                        decimal rightValue = decimal.Parse(parts[1].Trim());
                        if (!(leftValue > rightValue))
                        {
                            result = false;
                            break;
                        }
                    }
                    else if (trimmedCond.Contains("=="))
                    {
                        var parts = trimmedCond.Split(new[] { "==" }, StringSplitOptions.None);
                        string leftValue = parts[0].Trim();
                        string rightValue = parts[1].Trim();
                        
                        // Remove quotes if present
                        if (leftValue.StartsWith("'") && leftValue.EndsWith("'"))
                        {
                            leftValue = leftValue.Substring(1, leftValue.Length - 2);
                        }
                        
                        if (rightValue.StartsWith("'") && rightValue.EndsWith("'"))
                        {
                            rightValue = rightValue.Substring(1, rightValue.Length - 2);
                        }
                        
                        if (leftValue != rightValue)
                        {
                            result = false;
                            break;
                        }
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error evaluating condition: {Condition}", condition);
                return false;
            }
        }
    }
}