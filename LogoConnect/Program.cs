using LogoConnect;
using LogoConnect.Models;
using LogoConnect.Services;

var builder = WebApplication.CreateBuilder(args);

// Add WooService
builder.Services.AddScoped<IWooService, WooService>();

// Bind config
builder.Services.Configure<WooOptions>(builder.Configuration.GetSection("WooCommerce"));

// Register HttpClient + Woo service
builder.Services.AddHttpClient<IWooService, WooService>((sp, client) =>
{
    var opts = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<WooOptions>>().Value;
    client.BaseAddress = new Uri(opts.SiteUrl.TrimEnd('/') + "/wp-json/wc/v3/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    // Basic auth will be applied inside the service depending on config
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
       .AddEnvironmentVariables();

// LogoStore start
LogoStatusStore.Load();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
