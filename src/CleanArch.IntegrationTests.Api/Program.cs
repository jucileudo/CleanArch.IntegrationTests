


using CleanArch.IntegrationTests.Ioc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

app.ConfigureMiddleware();

app.Run();
