using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddControllers();

var authenticationProviderKey = "IdentityApiKey";

// NUGET - Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication()
 .AddJwtBearer(authenticationProviderKey, x =>
 {
     x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
                                             //x.RequireHttpsMetadata = false;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateAudience = false
     };
 });

builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();
