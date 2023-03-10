using Finanzauto.HuellaCarbono.Infra;
using Finanzauto.HuellaCarbono.App;
using Finanzauto.HuellaCarbono.Api.Configuration;
using System.Text;
using Finanzauto.HuellaCarbono.Auth;

var builder = WebApplication.CreateBuilder(args);

//Add Cors.

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCors", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});

//Add Controllers

builder.Services.AddControllers();

//Json File

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

//Enpoint Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();

app.UseCors("PolicyCors");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./v1/swagger.json", "Huella Carbono");
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
