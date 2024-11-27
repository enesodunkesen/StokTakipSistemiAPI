
using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IStockRepository<>), typeof(StockRepository<>));
            builder.Services.AddScoped(typeof(ICategoryRepository<>), typeof(CategoryRepository<>));
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<SaleService>();

            builder.Services.AddScoped<StockService>();
            builder.Services.AddScoped<StockMovementService>();
            builder.Services.AddScoped<TransferService>();
            builder.Services.AddScoped<WarehouseService>();

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
}
