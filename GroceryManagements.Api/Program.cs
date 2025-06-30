
using Grocery.Bl.IService;
using Grocery.Bl.MapFolder;
using Grocery.Bl.Service;
using Grocery.Db.ContextFolder;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagements.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CollectionContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"),
                    sqlOptions => sqlOptions.MigrationsAssembly("GroceryManagements.Api"));
            });
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IItemService,ItemService>();
            builder.Services.AddScoped<IStockService,StockService>();
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

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
}
