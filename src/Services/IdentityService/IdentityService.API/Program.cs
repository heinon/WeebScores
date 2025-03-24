using IdentityService.Application;
using IdentityService.Application.UserApplication.Command.CreateAdmin;
using IdentityService.Application.UserApplication.Command.RegisterUser;
using IdentityService.Infrastructure;
using Microsoft.OpenApi.Models;
using SharedKernel;
using SharedKernel.CQRS.Command;
using SharedKernel.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSharedKernel(builder.Configuration);

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddJwtAuthentication(jwtSettings.Secret, jwtSettings.ValidIssuer);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var commandBus = scope.ServiceProvider.GetRequiredService<ICommandBus>();
    await commandBus.SendAsync(new CreateAdminCommand());
}


app.Run();