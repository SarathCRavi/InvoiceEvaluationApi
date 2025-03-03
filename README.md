# InvoiceEvaluationApi
📌 Invoice Evaluation API
A .NET 8 Web API for processing invoices, validating data, integrating with a mock third-party service, applying business rules, and generating an evaluation summary.

🚀 Features
✅ Upload PDF invoice with JSON invoice details
✅ Validate invoice number, date, and amount
✅ Integrate with a mock third-party API for classification
✅ Apply configurable business rules for evaluation
✅ Generate an evaluation report in JSON format
✅ Unit and integration tests using NUnit

🛠️ Tech Stack
.NET 8 Web API
C#
Swashbuckle (Swagger UI)
Newtonsoft.Json
RestSharp (HTTP client for API calls)
Polly (Resilience & retries)
NUnit & Moq (Unit testing)

📂 Project Structure
📂 InvoiceEvaluationAPI
 ┣ 📂 Controllers        # API endpoints
 ┃ ┣ 📜 InvoiceController.cs
 ┣ 📂 Services           # Business logic (validation, rule processing)
 ┃ ┣ 📜 IInvoiceValidator.cs
 ┃ ┣ 📜 InvoiceValidator.cs
 ┃ ┣ 📜 IThirdPartyApiService.cs
 ┃ ┣ 📜 ThirdPartyApiService.cs
 ┃ ┣ 📜 IRuleEngineService.cs
 ┃ ┣ 📜 RuleEngineService.cs
 ┣ 📂 Models             # DTOs & domain models
 ┃ ┣ 📜 InvoiceRequest.cs
 ┃ ┣ 📜 InvoiceEvaluationResponse.cs
 ┃ ┣ 📜 Rule.cs
 ┣ 📂 Tests              # Unit & integration tests
 ┃ ┣ 📜 InvoiceValidatorTests.cs
 ┃ ┣ 📜 RuleEngineTests.cs
 ┃ ┣ 📜 IntegrationTests.cs
 ┣ 📜 Program.cs         # Entry point & DI configuration
 ┣ 📜 appsettings.json   # Configuration settings
 ┣ 📜 README.md          # Project documentation
 ┣ 📜 InvoiceEvaluationAPI.csproj  # Project file
 ┗ 📜 .gitignore         # Git ignored files
	
🔧 Setup & Installation
1️.Clone the Repository

git clone https://github.com/SarathCRavi/InvoiceEvaluationApi.git
cd InvoiceEvaluationAPI

2️.Install Dependencies
Ensure you have .NET 8 SDK installed, then restore dependencies:

dotnet restore

3️.Run the API

dotnet run
The API will start at http://localhost:5143.

4️.Access Swagger UI
Go to:
📌 http://localhost:5143/swagger

📌 API Endpoints
1️.Upload Invoice for Evaluation

	Endpoint: POST /evaluate
	Request Format: multipart/form-data
	Parameters:
		-file (PDF document)
		-invoiceDetails (JSON)
		
Example JSON Payload:
json

{
  "invoiceId": "12345",
  "invoiceNumber": "S12345",
  "invoiceDate": "2023-10-25T00:00:00",
  "comment": "Test invoice",
  "amount": 850.00
}

Response Example:
json

{
  "evaluationId": "EVAL001",
  "invoiceId": "12345",
  "rulesApplied": ["Approve"],
  "classification": "WaterLeakDetection",
  "evaluationFile": "Base64EncodedString"
}

🧪 Running Tests
To execute unit & integration tests, run:

dotnet test
✅ Ensures validation, API integration, and rule processing work correctly.

📜 License
This project is open-source.

📌 GitHub Repo: https://github.com/SarathCRavi/InvoiceEvaluationApi.git
