using AspNetCore.ReCaptcha;
using IdentityManager.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Observers.Data;
using Observers.Models;
using Observers.Services;
using Rotativa.AspNetCore;
using System.Configuration;
using System.Globalization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("IdentityManagerConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys\Observers"))
    .SetApplicationName("Observers");

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ObserversContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.UseCompatibilityLevel(100);
        }));

builder.Services.AddDbContext<IdentityManagerContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("IdentityManagerConnection")));

builder.Services.AddDbContext<cbsdbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("cbsConnection")));

builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
      opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();


builder.Services.Configure<RequestLocalizationOptions>(
 opt =>
 {
     var supportedCultures = new List<CultureInfo>
     {
                new CultureInfo("bs-Latn-BA"),
                new CultureInfo("bs-Cyrl-BA"),
                new CultureInfo("hr-BA"),
                new CultureInfo("en-GB")
     };
     opt.DefaultRequestCulture = new RequestCulture("bs-Latn-BA");
     opt.SupportedCultures = supportedCultures;
     opt.SupportedUICultures = supportedCultures;
 });

builder.Services.AddHttpClient("Location", options =>
{
    options.BaseAddress = new Uri("http://api.ipstack.com");
});
builder.Services.AddScoped<IApiClientService, ApiClientService>();
builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddControllers()
        .AddNewtonsoftJson(jsonOptions =>
        {
            //jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
            jsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();

        });


builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("Content-Security-Policy",
    "default-src 'self' 'unsafe-inline'; " +
    "script-src 'self' cdnjs.cloudflare.com https://www.google.com/recaptcha/ https://www.gstatic.com/recaptcha/ https://www.gstatic.com/recaptcha/releases/ 'unsafe-inline' 'unsafe-eval';" +
    "frame-src 'self' https://www.google.com/recaptcha/ https://recaptcha.google.com/recaptcha/" +
    ";style-src 'self' fonts.googleapis.com 'unsafe-inline'; " +
    "font-src 'self' data: fonts.googleapis.com fonts.gstatic.com;" +
    "img-src 'self' data:");

    context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");


    await next();
});

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU0MDAzQDMxMzkyZTM0MmUzMEJiTllpOUhTZXVIY2crYWFSS21BcE8vS0tEQ0pFdDZIWC80bnhrNVhEb3M9");
app.UseCookiePolicy(
           new CookiePolicyOptions
           {
               Secure = CookieSecurePolicy.Always
           });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment,"..\\Rotativa\\");

app.Run();
