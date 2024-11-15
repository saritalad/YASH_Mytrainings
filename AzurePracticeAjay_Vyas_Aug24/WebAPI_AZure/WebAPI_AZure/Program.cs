
using Microsoft.EntityFrameworkCore;
using WebAPI_AZure.Models;

namespace WebAPI_AZure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("myconstr") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");

            builder.Services.AddDbContext<AppDBContext>(options =>
               options.UseSqlServer(connectionString));
            builder.Services.AddCors(c =>
            {
                c.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
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

            app.UseAuthorization();
            app.UseCors();
            app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}
