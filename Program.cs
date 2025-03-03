using InvoiceEvaluationAPI.Services;
using InvoiceEvaluationAPI.Validators;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http.Features;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Invoice Evaluation API", Version = "v1" });
});

// Configure logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

// Register services (will implement these later)
builder.Services.AddScoped<IInvoiceValidator, InvoiceValidator>();
builder.Services.AddScoped<IThirdPartyApiService, ThirdPartyApiService>();
builder.Services.AddScoped<IRuleEngineService, RuleEngineService>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit = 100_000_000; // 100MB
});


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();