# InvoiceEvaluationApi
This project involves creating a .NET 8/9 Web API for invoice evaluation. It includes setting up a project, implementing an API endpoint to receive invoice data, integrating with a mock 3rd-party API, processing decision rules, generating evaluation summaries, and writing unit and integration tests.

Step 1: Project Setup 
•	Create a new .NET 8/9 Web API project.
•	Add basic dependencies (e.g., Swashbuckle for Swagger, Newtonsoft.Json, Polly).
•	Provide a github link to the project’s repo
✅ Deliverable: A structured .NET project with initial setup.
________________________________________
Step 2: API to Receive Invoice & JSON Data
•	Implement a POST /evaluate endpoint that accepts:
o	A document (PDF).
o	A JSON payload with invoice details
	Invoice ID
	Invoice number (by the craftsman) // e.g. S12345 must start with “S” with 5 digits
	Invoice date
	Comment (by the insurance company)
	Amount
•	Validate input format, required fields, and file size.
•	Include logging
✅ Deliverable: A working API endpoint that validates input.
________________________________________
Step 3: Mock 3rd-Party API Integration (1 Hour)
•	Implement a service class that calls a mock 3rd-party API to gather invoice classifications upon sending the document
•	Example mock response:
{
  "classification": "WaterLeakDetection", // other could be “RoofingTileReplacement”, “FireDamagedWallRepair”, “BrokenDoorRepair”, “Basement Waterproofing”
  "riskLevel": "Low"
}
•	Use restsharp with proper retry/error handling.
o	You can use any tool to mock or host the 3rd party api
✅ Deliverable: A service that interacts with a mock 3rd-party API.
________________________________________
[OPTIONAL] Step 4: Decision Rules Processing
•	Implement a simple decision table in JSON/CSV or other format that a non-technical operation manager could edit
RuleId, Condition, Action
1, "amount < 1000 AND riskLevel == 'Low'", "Approve"
2, "classification == 'FireDamagedWallRepair' AND riskLevel == 'High'", "Flag for Review"
•	Create a rule engine that applies matching rules to incoming data.
✅ Deliverable: A rule-processing service that evaluates invoice data.
________________________________________
Step 5: Generate Evaluation Summary
•	Create a JSON summary report as the response of POST /evaluate:
{
  "evaluationId": "EVAL001", // make it up
  "invoiceId": "12345",
  "rulesApplied": ["Approve"],
  "classification": "WaterLeakDetection",
  “evaluationFile”: “Base64String”// Generate an attached text file as evaluation summary that explains the result in plain English sentences.
}
✅ Deliverable: A JSON response with an evaluation document.
________________________________________
Step 6: Unit & Integration Tests
•	Write at least 2 unit tests 
•	Write 1 integration test for:
o	The /evaluate endpoint with a real request.
•	Use NUnit for testing.
✅ Deliverable: Unit tests and an integration test with a test report.
