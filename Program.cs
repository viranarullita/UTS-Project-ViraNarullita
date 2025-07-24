using Microsoft.EntityFrameworkCore;
using UTS_Project_ViraNarullita.Models;
using UTS_Project_ViraNarullita.Models.DTO;
using UTS_Project_ViraNarullita.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        // Replace 'YourDbContext' with the name of your own DbContext derived class.
        builder.Services.AddDbContext<ApplicationContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"), serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

        builder.Services.AddScoped<PesananService>();
        builder.Services.AddScoped<ProdukService>();

        // Add services to the container.

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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}