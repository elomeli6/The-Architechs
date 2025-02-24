using project_wildfire_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using project_wildfire_web.Areas.Identity.Data;

namespace project_wildfire_web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add wildfire database context
        // Grabs & null checks password from user secrets
        var DbPassword = builder.Configuration["WildfireProj:DBPassword"]
            ?? throw new InvalidOperationException("Database Password Not Found");

        // Grabs & null checks connection string from appsettings.json
        var PartialConnectionString = builder.Configuration.GetConnectionString("WebfireDbConnectionString") 
            ?? throw new InvalidOperationException("Connection String Not Found");

        // Replaces placeholder password with actual password
        var FullConnectionString = PartialConnectionString.Replace("STANDINPASSWORD", DbPassword);

        // Add database context with NetTopologySuite enabled
        builder.Services.AddDbContext<WildfireDbContext>(options =>
            options.UseSqlServer(
                FullConnectionString,
                x => x.UseNetTopologySuite())
                );

        // Add Identity database context
        // Grabs & null checks connection string from appsettings.json
        var IdentityDbPartialConnectionString = builder.Configuration.GetConnectionString("WebfireIdentityDbContextConnection")
            ?? throw new InvalidOperationException("Connection String Not Found");

        // Replaces placeholder password with actual password
        var IdentityDbFullConnectionString = IdentityDbPartialConnectionString.Replace("STANDINPASSWORD", DbPassword);

        // Add Identity database context
        builder.Services.AddDbContext<WebfireIdentityDbContext>(options =>
            options.UseSqlServer(IdentityDbFullConnectionString));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebfireIdentityDbContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.MapRazorPages();

        app.Run();
    }
}
