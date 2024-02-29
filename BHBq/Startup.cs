using System.Drawing;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<BHBqContext>(
            options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddControllersWithViews();
        services.AddElectron();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}"
            );
        });
        // Start the application
        Task.Run(async () =>
        {
            var options = new BrowserWindowOptions
            {
                Width = 1024, // Largeur par défaut de la fenêtre
                Height = 768, // Hauteur par défaut de la fenêtre
                MinWidth = 800, // Largeur minimale de la fenêtre
                MinHeight = 600, // Hauteur minimale de la fenêtre
                MaxWidth = 1920, // Largeur maximale de la fenêtre
                MaxHeight = 1080, // Hauteur maximale de la fenêtre
                Center = true,  // Centrer la fenêtre
                AutoHideMenuBar = true, // Masquer la barre de menu
                Icon = Path.Combine(env.ContentRootPath, "build", "LogoBHBqIcon.png"), // Icône de la fenêtre
            };
            await Electron.WindowManager.CreateWindowAsync(options);
            
        });
    }
}
