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

            //ToDoListRepository repository = new ToDoListRepository(new Entities.Configs.DataBaseCreds()
            //{
            //    Host = "192.168.133.128",
            //    Password = "123qwe45asd",
            //    Port = 5432,
            //    UserName = "postgres"
            //});

             
            ToDoListRepository repository = new ToDoListRepository(new Entities.Configs.DataBaseCreds()
            {
                /// получение Environment-ов прокинутые в docker
                Host = Environment.GetEnvironmentVariable("DbHost"),
                Port = int.Parse(Environment.GetEnvironmentVariable("DbPort")),
                Password = Environment.GetEnvironmentVariable("DbPass"),
                UserName = Environment.GetEnvironmentVariable("DbUserName")
            });

            builder.Services.AddSingleton<IToDoListRepository>(repository);
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("*")
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
            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}