
using System.Reflection;
using WebAppTask.Server.Helper;
using WebAppTask.Server.Maps;

namespace WebAppTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(MyListMappingProfile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<SortHelper>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                  builder => builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
            });

            var app = builder.Build();

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllers();


            app.Run();
        }
    }
}
