using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using laxmanPMS.web.Data;
using LaxmanSMS.web.Data;
using laxmanPMS.web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using laxmanPMS.Infrastructure.Services;
using laxmanPMS.Infrastructure;
using laxmanPMS.Infrastructure.IRepository.ICrudService;
using laxmanPMS.Infrastructure.Repository.CRUD;

namespace laxmanPMS.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<PMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            e => e.MigrationsAssembly("laxmanPMS.web")));

            builder.Services.AddTransient(typeof(ICrudService<>), typeof(CrudService<>));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddSingleton<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await SeedingData.InitializeAsync(services);
            }
            app.Run();
        }
    }
}
