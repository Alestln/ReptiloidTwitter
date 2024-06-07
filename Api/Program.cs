using System.Security.Authentication;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using ReptiloidTwitter.Configuration;
using ReptiloidTwitter.Services.Authentication;

namespace ReptiloidTwitter;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(opt => 
            opt.AddDefaultPolicy(policy => 
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

        builder.Services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();
        
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        var jwtCredentials = builder.Configuration.GetSection("Jwt").Get<JwtCredentials>();

        if (jwtCredentials is not null)
        {
            builder.Services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtCredentials.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtCredentials.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtCredentials.SecurityKey
                    };
                });
        }
        else
        {
            throw new AuthenticationException($"JwtCredentials is null. Place of error: {nameof(Program)}");
        }
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}