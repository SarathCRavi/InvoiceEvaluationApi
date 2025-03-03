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
InvoiceEvaluationApi/
├── Configuration
│   └── rules.json
├── Controllers
│   ├── Controllers
│   ├── EvaluationController.cs
│   ├── Models
│   │   ├── Services
│   │   │   └── Services
│   │   │       ├── Models
│   │   │       │   ├── Models
│   │   │       │   │   ├── InvoiceEvaluation.cs
│   │   │       │   │   └── Services
│   │   │       │   │       └── Services
│   │   │       │   │           ├── Configuration
│   │   │       │   │           │   ├── Models
│   │   │       │   │           │   │   ├── EvaluationSummary.cs
│   │   │       │   │           │   │   └── Services
│   │   │       │   │           │   │       ├── IEvaluationService.cs
│   │   │       │   │           │   │       └── Services
│   │   │       │   │           │   │           ├── Controllers
│   │   │       │   │           │   │           └── EvaluationService.cs
│   │   │       │   │           │   └── rules.json
│   │   │       │   │           └── RuleEngineService.cs
│   │   │       │   └── Rule.cs
│   │   │       └── ThirdPartyApiService.cs
│   │   └── ThirdPartyApiResponse.cs
│   └── Services
│       ├── IRuleEngineService.cs
│       └── Services
│           └── IThirdPartyApiService.cs
├── EvaluationControllerIntegrationTests.cs
├── Helpers
├── InvoiceDocument.pdf
├── InvoiceEvaluationAPI.Tests
│   ├── InvoiceEvaluationAPI.Tests.csproj
│   ├── UnitTest1.cs
│   ├── bin
│   │   └── Debug
│   │       └── net8.0
│   └── obj
│       ├── Debug
│       │   └── net8.0
│       │       ├── InvoiceEvaluationAPI.Tests.GlobalUsings.g.cs
│       │       ├── InvoiceEvaluationAPI.Tests.assets.cache
│       │       ├── InvoiceEvaluationAPI.Tests.csproj.FileListAbsolute.txt
│       │       ├── ref
│       │       └── refint
│       ├── InvoiceEvaluationAPI.Tests.csproj.nuget.dgspec.json
│       ├── InvoiceEvaluationAPI.Tests.csproj.nuget.g.props
│       ├── InvoiceEvaluationAPI.Tests.csproj.nuget.g.targets
│       ├── project.assets.json
│       └── project.nuget.cache
├── InvoiceEvaluationAPI.csproj
├── InvoiceEvaluationAPI.http
├── InvoiceEvaluationAPI.sln
├── InvoiceValidatorTests.cs
├── Models
│   ├── InvoiceRequest.cs
│   └── UnitTest
│       └── InvoiceValidatorTests.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── README.md
├── RuleEngineServiceTests.cs
├── Services
│   ├── IInvoiceValidator.cs
│   └── Services
│       └── InvoiceValidator.cs
├── Validators
├── appsettings.Development.json
├── appsettings.json
├── bin
│   └── Debug
│       └── net8.0
│           ├── Castle.Core.dll
│           ├── Configuration
│           │   └── rules.json
│           ├── Controllers
│           │   └── Models
│           │       └── Services
│           │           └── Services
│           │               └── Models
│           │                   └── Models
│           │                       └── Services
│           │                           └── Services
│           │                               └── Configuration
│           │                                   └── rules.json
│           ├── InvoiceEvaluationAPI.Tests
│           │   └── obj
│           │       ├── InvoiceEvaluationAPI.Tests.csproj.nuget.dgspec.json
│           │       └── project.assets.json
│           ├── InvoiceEvaluationAPI.deps.json
│           ├── InvoiceEvaluationAPI.dll
│           ├── InvoiceEvaluationAPI.exe
│           ├── InvoiceEvaluationAPI.pdb
│           ├── InvoiceEvaluationAPI.runtimeconfig.json
│           ├── Microsoft.ApplicationInsights.dll
│           ├── Microsoft.AspNetCore.Mvc.Testing.dll
│           ├── Microsoft.AspNetCore.OpenApi.dll
│           ├── Microsoft.AspNetCore.TestHost.dll
│           ├── Microsoft.Extensions.DependencyModel.dll
│           ├── Microsoft.OpenApi.dll
│           ├── Microsoft.TestPlatform.CommunicationUtilities.dll
│           ├── Microsoft.TestPlatform.CoreUtilities.dll
│           ├── Microsoft.TestPlatform.CrossPlatEngine.dll
│           ├── Microsoft.TestPlatform.PlatformAbstractions.dll
│           ├── Microsoft.TestPlatform.Utilities.dll
│           ├── Microsoft.Testing.Extensions.MSBuild.dll
│           ├── Microsoft.Testing.Extensions.Telemetry.dll
│           ├── Microsoft.Testing.Extensions.TrxReport.Abstractions.dll
│           ├── Microsoft.Testing.Extensions.VSTestBridge.dll
│           ├── Microsoft.Testing.Platform.dll
│           ├── Microsoft.VisualStudio.CodeCoverage.Shim.dll
│           ├── Microsoft.VisualStudio.TestPlatform.Common.dll
│           ├── Microsoft.VisualStudio.TestPlatform.ObjectModel.dll
│           ├── Moq.dll
│           ├── MvcTestingAppManifest.json
│           ├── NUnit3.TestAdapter.dll
│           ├── NUnit3.TestAdapter.pdb
│           ├── Newtonsoft.Json.dll
│           ├── Polly.Core.dll
│           ├── Polly.dll
│           ├── RestSharp.dll
│           ├── Swashbuckle.AspNetCore.Swagger.dll
│           ├── Swashbuckle.AspNetCore.SwaggerGen.dll
│           ├── Swashbuckle.AspNetCore.SwaggerUI.dll
│           ├── appsettings.Development.json
│           ├── appsettings.json
│           ├── cs
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── de
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── es
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── fr
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── it
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── ja
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── ko
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── nunit.engine.api.dll
│           ├── nunit.engine.core.dll
│           ├── nunit.engine.dll
│           ├── nunit.framework.dll
│           ├── nunit_random_seed.tmp
│           ├── pl
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── pt-BR
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── refs
│           │   ├── Microsoft.AspNetCore.Antiforgery.dll
│           │   ├── Microsoft.AspNetCore.Authentication.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Authentication.BearerToken.dll
│           │   ├── Microsoft.AspNetCore.Authentication.Cookies.dll
│           │   ├── Microsoft.AspNetCore.Authentication.Core.dll
│           │   ├── Microsoft.AspNetCore.Authentication.OAuth.dll
│           │   ├── Microsoft.AspNetCore.Authentication.dll
│           │   ├── Microsoft.AspNetCore.Authorization.Policy.dll
│           │   ├── Microsoft.AspNetCore.Authorization.dll
│           │   ├── Microsoft.AspNetCore.Components.Authorization.dll
│           │   ├── Microsoft.AspNetCore.Components.Endpoints.dll
│           │   ├── Microsoft.AspNetCore.Components.Forms.dll
│           │   ├── Microsoft.AspNetCore.Components.Server.dll
│           │   ├── Microsoft.AspNetCore.Components.Web.dll
│           │   ├── Microsoft.AspNetCore.Components.dll
│           │   ├── Microsoft.AspNetCore.Connections.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.CookiePolicy.dll
│           │   ├── Microsoft.AspNetCore.Cors.dll
│           │   ├── Microsoft.AspNetCore.Cryptography.Internal.dll
│           │   ├── Microsoft.AspNetCore.Cryptography.KeyDerivation.dll
│           │   ├── Microsoft.AspNetCore.DataProtection.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.DataProtection.Extensions.dll
│           │   ├── Microsoft.AspNetCore.DataProtection.dll
│           │   ├── Microsoft.AspNetCore.Diagnostics.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Diagnostics.HealthChecks.dll
│           │   ├── Microsoft.AspNetCore.Diagnostics.dll
│           │   ├── Microsoft.AspNetCore.HostFiltering.dll
│           │   ├── Microsoft.AspNetCore.Hosting.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Hosting.Server.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Hosting.dll
│           │   ├── Microsoft.AspNetCore.Html.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Http.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Http.Connections.Common.dll
│           │   ├── Microsoft.AspNetCore.Http.Connections.dll
│           │   ├── Microsoft.AspNetCore.Http.Extensions.dll
│           │   ├── Microsoft.AspNetCore.Http.Features.dll
│           │   ├── Microsoft.AspNetCore.Http.Results.dll
│           │   ├── Microsoft.AspNetCore.Http.dll
│           │   ├── Microsoft.AspNetCore.HttpLogging.dll
│           │   ├── Microsoft.AspNetCore.HttpOverrides.dll
│           │   ├── Microsoft.AspNetCore.HttpsPolicy.dll
│           │   ├── Microsoft.AspNetCore.Identity.dll
│           │   ├── Microsoft.AspNetCore.Localization.Routing.dll
│           │   ├── Microsoft.AspNetCore.Localization.dll
│           │   ├── Microsoft.AspNetCore.Metadata.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Mvc.ApiExplorer.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Core.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Cors.dll
│           │   ├── Microsoft.AspNetCore.Mvc.DataAnnotations.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Formatters.Json.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Formatters.Xml.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Localization.dll
│           │   ├── Microsoft.AspNetCore.Mvc.Razor.dll
│           │   ├── Microsoft.AspNetCore.Mvc.RazorPages.dll
│           │   ├── Microsoft.AspNetCore.Mvc.TagHelpers.dll
│           │   ├── Microsoft.AspNetCore.Mvc.ViewFeatures.dll
│           │   ├── Microsoft.AspNetCore.Mvc.dll
│           │   ├── Microsoft.AspNetCore.OutputCaching.dll
│           │   ├── Microsoft.AspNetCore.RateLimiting.dll
│           │   ├── Microsoft.AspNetCore.Razor.Runtime.dll
│           │   ├── Microsoft.AspNetCore.Razor.dll
│           │   ├── Microsoft.AspNetCore.RequestDecompression.dll
│           │   ├── Microsoft.AspNetCore.ResponseCaching.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.ResponseCaching.dll
│           │   ├── Microsoft.AspNetCore.ResponseCompression.dll
│           │   ├── Microsoft.AspNetCore.Rewrite.dll
│           │   ├── Microsoft.AspNetCore.Routing.Abstractions.dll
│           │   ├── Microsoft.AspNetCore.Routing.dll
│           │   ├── Microsoft.AspNetCore.Server.HttpSys.dll
│           │   ├── Microsoft.AspNetCore.Server.IIS.dll
│           │   ├── Microsoft.AspNetCore.Server.IISIntegration.dll
│           │   ├── Microsoft.AspNetCore.Server.Kestrel.Core.dll
│           │   ├── Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.dll
│           │   ├── Microsoft.AspNetCore.Server.Kestrel.Transport.Quic.dll
│           │   ├── Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.dll
│           │   ├── Microsoft.AspNetCore.Server.Kestrel.dll
│           │   ├── Microsoft.AspNetCore.Session.dll
│           │   ├── Microsoft.AspNetCore.SignalR.Common.dll
│           │   ├── Microsoft.AspNetCore.SignalR.Core.dll
│           │   ├── Microsoft.AspNetCore.SignalR.Protocols.Json.dll
│           │   ├── Microsoft.AspNetCore.SignalR.dll
│           │   ├── Microsoft.AspNetCore.StaticFiles.dll
│           │   ├── Microsoft.AspNetCore.WebSockets.dll
│           │   ├── Microsoft.AspNetCore.WebUtilities.dll
│           │   ├── Microsoft.AspNetCore.dll
│           │   ├── Microsoft.CSharp.dll
│           │   ├── Microsoft.Extensions.Caching.Abstractions.dll
│           │   ├── Microsoft.Extensions.Caching.Memory.dll
│           │   ├── Microsoft.Extensions.Configuration.Abstractions.dll
│           │   ├── Microsoft.Extensions.Configuration.Binder.dll
│           │   ├── Microsoft.Extensions.Configuration.CommandLine.dll
│           │   ├── Microsoft.Extensions.Configuration.EnvironmentVariables.dll
│           │   ├── Microsoft.Extensions.Configuration.FileExtensions.dll
│           │   ├── Microsoft.Extensions.Configuration.Ini.dll
│           │   ├── Microsoft.Extensions.Configuration.Json.dll
│           │   ├── Microsoft.Extensions.Configuration.KeyPerFile.dll
│           │   ├── Microsoft.Extensions.Configuration.UserSecrets.dll
│           │   ├── Microsoft.Extensions.Configuration.Xml.dll
│           │   ├── Microsoft.Extensions.Configuration.dll
│           │   ├── Microsoft.Extensions.DependencyInjection.Abstractions.dll
│           │   ├── Microsoft.Extensions.DependencyInjection.dll
│           │   ├── Microsoft.Extensions.Diagnostics.Abstractions.dll
│           │   ├── Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.dll
│           │   ├── Microsoft.Extensions.Diagnostics.HealthChecks.dll
│           │   ├── Microsoft.Extensions.Diagnostics.dll
│           │   ├── Microsoft.Extensions.Features.dll
│           │   ├── Microsoft.Extensions.FileProviders.Abstractions.dll
│           │   ├── Microsoft.Extensions.FileProviders.Composite.dll
│           │   ├── Microsoft.Extensions.FileProviders.Embedded.dll
│           │   ├── Microsoft.Extensions.FileProviders.Physical.dll
│           │   ├── Microsoft.Extensions.FileSystemGlobbing.dll
│           │   ├── Microsoft.Extensions.Hosting.Abstractions.dll
│           │   ├── Microsoft.Extensions.Hosting.dll
│           │   ├── Microsoft.Extensions.Http.dll
│           │   ├── Microsoft.Extensions.Identity.Core.dll
│           │   ├── Microsoft.Extensions.Identity.Stores.dll
│           │   ├── Microsoft.Extensions.Localization.Abstractions.dll
│           │   ├── Microsoft.Extensions.Localization.dll
│           │   ├── Microsoft.Extensions.Logging.Abstractions.dll
│           │   ├── Microsoft.Extensions.Logging.Configuration.dll
│           │   ├── Microsoft.Extensions.Logging.Console.dll
│           │   ├── Microsoft.Extensions.Logging.Debug.dll
│           │   ├── Microsoft.Extensions.Logging.EventLog.dll
│           │   ├── Microsoft.Extensions.Logging.EventSource.dll
│           │   ├── Microsoft.Extensions.Logging.TraceSource.dll
│           │   ├── Microsoft.Extensions.Logging.dll
│           │   ├── Microsoft.Extensions.ObjectPool.dll
│           │   ├── Microsoft.Extensions.Options.ConfigurationExtensions.dll
│           │   ├── Microsoft.Extensions.Options.DataAnnotations.dll
│           │   ├── Microsoft.Extensions.Options.dll
│           │   ├── Microsoft.Extensions.Primitives.dll
│           │   ├── Microsoft.Extensions.WebEncoders.dll
│           │   ├── Microsoft.JSInterop.dll
│           │   ├── Microsoft.Net.Http.Headers.dll
│           │   ├── Microsoft.VisualBasic.Core.dll
│           │   ├── Microsoft.VisualBasic.dll
│           │   ├── Microsoft.Win32.Primitives.dll
│           │   ├── Microsoft.Win32.Registry.dll
│           │   ├── System.AppContext.dll
│           │   ├── System.Buffers.dll
│           │   ├── System.Collections.Concurrent.dll
│           │   ├── System.Collections.Immutable.dll
│           │   ├── System.Collections.NonGeneric.dll
│           │   ├── System.Collections.Specialized.dll
│           │   ├── System.Collections.dll
│           │   ├── System.ComponentModel.Annotations.dll
│           │   ├── System.ComponentModel.DataAnnotations.dll
│           │   ├── System.ComponentModel.EventBasedAsync.dll
│           │   ├── System.ComponentModel.Primitives.dll
│           │   ├── System.ComponentModel.TypeConverter.dll
│           │   ├── System.ComponentModel.dll
│           │   ├── System.Configuration.dll
│           │   ├── System.Console.dll
│           │   ├── System.Core.dll
│           │   ├── System.Data.Common.dll
│           │   ├── System.Data.DataSetExtensions.dll
│           │   ├── System.Data.dll
│           │   ├── System.Diagnostics.Contracts.dll
│           │   ├── System.Diagnostics.Debug.dll
│           │   ├── System.Diagnostics.DiagnosticSource.dll
│           │   ├── System.Diagnostics.EventLog.dll
│           │   ├── System.Diagnostics.FileVersionInfo.dll
│           │   ├── System.Diagnostics.Process.dll
│           │   ├── System.Diagnostics.StackTrace.dll
│           │   ├── System.Diagnostics.TextWriterTraceListener.dll
│           │   ├── System.Diagnostics.Tools.dll
│           │   ├── System.Diagnostics.TraceSource.dll
│           │   ├── System.Diagnostics.Tracing.dll
│           │   ├── System.Drawing.Primitives.dll
│           │   ├── System.Drawing.dll
│           │   ├── System.Dynamic.Runtime.dll
│           │   ├── System.Formats.Asn1.dll
│           │   ├── System.Formats.Tar.dll
│           │   ├── System.Globalization.Calendars.dll
│           │   ├── System.Globalization.Extensions.dll
│           │   ├── System.Globalization.dll
│           │   ├── System.IO.Compression.Brotli.dll
│           │   ├── System.IO.Compression.FileSystem.dll
│           │   ├── System.IO.Compression.ZipFile.dll
│           │   ├── System.IO.Compression.dll
│           │   ├── System.IO.FileSystem.AccessControl.dll
│           │   ├── System.IO.FileSystem.DriveInfo.dll
│           │   ├── System.IO.FileSystem.Primitives.dll
│           │   ├── System.IO.FileSystem.Watcher.dll
│           │   ├── System.IO.FileSystem.dll
│           │   ├── System.IO.IsolatedStorage.dll
│           │   ├── System.IO.MemoryMappedFiles.dll
│           │   ├── System.IO.Pipelines.dll
│           │   ├── System.IO.Pipes.AccessControl.dll
│           │   ├── System.IO.Pipes.dll
│           │   ├── System.IO.UnmanagedMemoryStream.dll
│           │   ├── System.IO.dll
│           │   ├── System.Linq.Expressions.dll
│           │   ├── System.Linq.Parallel.dll
│           │   ├── System.Linq.Queryable.dll
│           │   ├── System.Linq.dll
│           │   ├── System.Memory.dll
│           │   ├── System.Net.Http.Json.dll
│           │   ├── System.Net.Http.dll
│           │   ├── System.Net.HttpListener.dll
│           │   ├── System.Net.Mail.dll
│           │   ├── System.Net.NameResolution.dll
│           │   ├── System.Net.NetworkInformation.dll
│           │   ├── System.Net.Ping.dll
│           │   ├── System.Net.Primitives.dll
│           │   ├── System.Net.Quic.dll
│           │   ├── System.Net.Requests.dll
│           │   ├── System.Net.Security.dll
│           │   ├── System.Net.ServicePoint.dll
│           │   ├── System.Net.Sockets.dll
│           │   ├── System.Net.WebClient.dll
│           │   ├── System.Net.WebHeaderCollection.dll
│           │   ├── System.Net.WebProxy.dll
│           │   ├── System.Net.WebSockets.Client.dll
│           │   ├── System.Net.WebSockets.dll
│           │   ├── System.Net.dll
│           │   ├── System.Numerics.Vectors.dll
│           │   ├── System.Numerics.dll
│           │   ├── System.ObjectModel.dll
│           │   ├── System.Reflection.DispatchProxy.dll
│           │   ├── System.Reflection.Emit.ILGeneration.dll
│           │   ├── System.Reflection.Emit.Lightweight.dll
│           │   ├── System.Reflection.Emit.dll
│           │   ├── System.Reflection.Extensions.dll
│           │   ├── System.Reflection.Metadata.dll
│           │   ├── System.Reflection.Primitives.dll
│           │   ├── System.Reflection.TypeExtensions.dll
│           │   ├── System.Reflection.dll
│           │   ├── System.Resources.Reader.dll
│           │   ├── System.Resources.ResourceManager.dll
│           │   ├── System.Resources.Writer.dll
│           │   ├── System.Runtime.CompilerServices.Unsafe.dll
│           │   ├── System.Runtime.CompilerServices.VisualC.dll
│           │   ├── System.Runtime.Extensions.dll
│           │   ├── System.Runtime.Handles.dll
│           │   ├── System.Runtime.InteropServices.JavaScript.dll
│           │   ├── System.Runtime.InteropServices.RuntimeInformation.dll
│           │   ├── System.Runtime.InteropServices.dll
│           │   ├── System.Runtime.Intrinsics.dll
│           │   ├── System.Runtime.Loader.dll
│           │   ├── System.Runtime.Numerics.dll
│           │   ├── System.Runtime.Serialization.Formatters.dll
│           │   ├── System.Runtime.Serialization.Json.dll
│           │   ├── System.Runtime.Serialization.Primitives.dll
│           │   ├── System.Runtime.Serialization.Xml.dll
│           │   ├── System.Runtime.Serialization.dll
│           │   ├── System.Runtime.dll
│           │   ├── System.Security.AccessControl.dll
│           │   ├── System.Security.Claims.dll
│           │   ├── System.Security.Cryptography.Algorithms.dll
│           │   ├── System.Security.Cryptography.Cng.dll
│           │   ├── System.Security.Cryptography.Csp.dll
│           │   ├── System.Security.Cryptography.Encoding.dll
│           │   ├── System.Security.Cryptography.OpenSsl.dll
│           │   ├── System.Security.Cryptography.Primitives.dll
│           │   ├── System.Security.Cryptography.X509Certificates.dll
│           │   ├── System.Security.Cryptography.Xml.dll
│           │   ├── System.Security.Cryptography.dll
│           │   ├── System.Security.Principal.Windows.dll
│           │   ├── System.Security.Principal.dll
│           │   ├── System.Security.SecureString.dll
│           │   ├── System.Security.dll
│           │   ├── System.ServiceModel.Web.dll
│           │   ├── System.ServiceProcess.dll
│           │   ├── System.Text.Encoding.CodePages.dll
│           │   ├── System.Text.Encoding.Extensions.dll
│           │   ├── System.Text.Encoding.dll
│           │   ├── System.Text.Encodings.Web.dll
│           │   ├── System.Text.Json.dll
│           │   ├── System.Text.RegularExpressions.dll
│           │   ├── System.Threading.Channels.dll
│           │   ├── System.Threading.Overlapped.dll
│           │   ├── System.Threading.RateLimiting.dll
│           │   ├── System.Threading.Tasks.Dataflow.dll
│           │   ├── System.Threading.Tasks.Extensions.dll
│           │   ├── System.Threading.Tasks.Parallel.dll
│           │   ├── System.Threading.Tasks.dll
│           │   ├── System.Threading.Thread.dll
│           │   ├── System.Threading.ThreadPool.dll
│           │   ├── System.Threading.Timer.dll
│           │   ├── System.Threading.dll
│           │   ├── System.Transactions.Local.dll
│           │   ├── System.Transactions.dll
│           │   ├── System.ValueTuple.dll
│           │   ├── System.Web.HttpUtility.dll
│           │   ├── System.Web.dll
│           │   ├── System.Windows.dll
│           │   ├── System.Xml.Linq.dll
│           │   ├── System.Xml.ReaderWriter.dll
│           │   ├── System.Xml.Serialization.dll
│           │   ├── System.Xml.XDocument.dll
│           │   ├── System.Xml.XPath.XDocument.dll
│           │   ├── System.Xml.XPath.dll
│           │   ├── System.Xml.XmlDocument.dll
│           │   ├── System.Xml.XmlSerializer.dll
│           │   ├── System.Xml.dll
│           │   ├── System.dll
│           │   ├── WindowsBase.dll
│           │   ├── mscorlib.dll
│           │   └── netstandard.dll
│           ├── ru
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── testcentric.engine.metadata.dll
│           ├── testhost.dll
│           ├── testhost.exe
│           ├── tr
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           ├── zh-Hans
│           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│           │   ├── Microsoft.Testing.Platform.resources.dll
│           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│           └── zh-Hant
│               ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│               ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│               ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│               ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│               ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│               ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│               ├── Microsoft.Testing.Platform.resources.dll
│               ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│               └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
└── obj
    ├── Debug
    │   └── net8.0
    │       ├── InvoiceE.FD801455.Up2Date
    │       ├── InvoiceEvaluationAPI.AssemblyInfo.cs
    │       ├── InvoiceEvaluationAPI.AssemblyInfoInputs.cache
    │       ├── InvoiceEvaluationAPI.GeneratedMSBuildEditorConfig.editorconfig
    │       ├── InvoiceEvaluationAPI.GlobalUsings.g.cs
    │       ├── InvoiceEvaluationAPI.MvcApplicationPartsAssemblyInfo.cache
    │       ├── InvoiceEvaluationAPI.MvcApplicationPartsAssemblyInfo.cs
    │       ├── InvoiceEvaluationAPI.assets.cache
    │       ├── InvoiceEvaluationAPI.csproj.AssemblyReference.cache
    │       ├── InvoiceEvaluationAPI.csproj.CoreCompileInputs.cache
    │       ├── InvoiceEvaluationAPI.csproj.FileListAbsolute.txt
    │       ├── InvoiceEvaluationAPI.dll
    │       ├── InvoiceEvaluationAPI.genruntimeconfig.cache
    │       ├── InvoiceEvaluationAPI.pdb
    │       ├── MvcTestingAppManifest.json
    │       ├── apphost.exe
    │       ├── ref
    │       │   └── InvoiceEvaluationAPI.dll
    │       ├── refint
    │       │   └── InvoiceEvaluationAPI.dll
    │       ├── staticwebassets
    │       │   ├── msbuild.build.InvoiceEvaluationAPI.props
    │       │   ├── msbuild.buildMultiTargeting.InvoiceEvaluationAPI.props
    │       │   └── msbuild.buildTransitive.InvoiceEvaluationAPI.props
    │       └── staticwebassets.build.json
    ├── InvoiceEvaluationAPI.csproj.nuget.dgspec.json
    ├── InvoiceEvaluationAPI.csproj.nuget.g.props
    ├── InvoiceEvaluationAPI.csproj.nuget.g.targets
    ├── project.assets.json
    └── project.nuget.cache
	
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
