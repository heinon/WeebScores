using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SharedKernel.Security;
using SharedKernel;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot Configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Configure JWT Authentication
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddJwtAuthentication(jwtSettings.Secret, jwtSettings.ValidIssuer);

// Add Ocelot and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOcelot();

var app = builder.Build();

// Middleware pipeline
app.UseAuthentication();
app.UseAuthorization();

app.Run();
