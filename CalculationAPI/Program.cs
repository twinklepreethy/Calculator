using CalculationUI;
using Factory;
using Interfaces.Repositories;
using Interfaces.Services;
using Repositories;
using Services;

namespace CalculationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IGetCalculationVMService, GetCalculationVMService>();
            builder.Services.AddSingleton<IPerformCalculationService, PerformCalculationService>();
            builder.Services.AddSingleton<ILogService, LogService>();
            builder.Services.AddSingleton<ICalculationRepository, CalculationRespository>();
            builder.Services.AddSingleton<IFunctionFactoryWrapper, FunctionFactoryWrapper>();

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

            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}