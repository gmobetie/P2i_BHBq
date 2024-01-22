using ElectronNET.API;
using ElectronNET.API.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseElectron(args);

// Add services to the container.
builder.Services.AddElectron();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BHBqContext>();

var app = builder.Build();

SeedData.Init();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

await app.StartAsync();
// Open the Electron-Window here
await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
{
    Width = 1024,
    Height = 768,
    Title = "Your App Title",
    // Other options...
});
app.WaitForShutdown();

