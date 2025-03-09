using Microsoft.EntityFrameworkCore;
using Serilog;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Mappings;
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

        builder.Services.AddRepository<CategoryDbo>();
        builder.Services.AddRepository<DishMenuItemDbo>();
        builder.Services.AddRepository<OrderDbo>();
        builder.Services.AddRepository<ReservationDbo>();

        builder.Services.AddAutoMapper(typeof(RestaurantMapping));
        //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        //builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddRestaurantServices();

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
        builder.Services.AddSwaggerGen();

        builder.Services.AddSerilog((ctx, conf) => conf.ReadFrom.Configuration(builder.Configuration));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}