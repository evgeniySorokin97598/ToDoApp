using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using ToDoList.Repositories.Interfaces;
using ToDoList.Repositories.Repositories;

namespace ToDoListBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            ToDoListRepository repository = new ToDoListRepository(new Entities.Configs.DataBaseCreds()
            {
                Host = "192.168.133.128",
                Password = "123qwe45asd",
                Port = 5432,
                UserName = "postgres"
            });

            builder.Services.AddSingleton<IToDoListRepository>(repository);
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //"Host=192.168.133.128;Port=5432;Database=Test1;Username=postgres;Password=123qwe45asd"

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}