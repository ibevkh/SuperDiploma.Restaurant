using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DomainService.Validators.ShopItems;
using SuperDiploma.Restaurant.Service.Setup;

namespace SuperDiploma.Restaurant.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<DbContext, RestaurantDbContext>();
        builder.Services.AddDbContext<RestaurantDbContext>(opt =>   //Це додає контекст бази даних CatContext до служб з використанням SQL.
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("SuperDiploma.Restaurant.Service"));
        });

        builder.Services.AddScoped<IRestaurantUnitOfWork, RestaurantUnitOfWork>();

        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddRestaurantRepositories();
        builder.Services.AddRestaurantMappers();
        builder.Services.AddRestaurantServices();
        builder.Services.AddRestaurantValidators();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policyBuilder =>
                {
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opts =>
        {
            
        });

        builder.Services.AddSerilog((ctx, conf) => conf.ReadFrom.Configuration(builder.Configuration));

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}