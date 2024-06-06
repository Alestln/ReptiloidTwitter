using Application;
using Persistence;

namespace ReptiloidTwitter;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(opt => 
            opt.AddDefaultPolicy(policy => 
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
        
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();
        
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}