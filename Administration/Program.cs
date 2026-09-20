using Administration.Models;
using Administration.Services;
using AspNetCore.ReCaptcha;
using Administration.Data;
using Administration.Models;
using Administration.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using IdentityManager.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var ERConnection = builder.Configuration.GetConnectionString("ERConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var PolitcalSubjectsConnection = builder.Configuration.GetConnectionString("PoliticalSubjectsConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var CandidatesConnection = builder.Configuration.GetConnectionString("CandidatesConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DefaultConnection));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<IdentityManagerContext>(options => options.UseSqlServer(DefaultConnection));

builder.Services.AddDbContext<PoliticalSubjectContext>(options => options.UseSqlServer(PolitcalSubjectsConnection));
builder.Services.AddDbContext<CandidatesContext>(options => options.UseSqlServer(CandidatesConnection));
builder.Services.AddDbContext<ElectionRepositoryContext>(options => options.UseSqlServer(ERConnection));

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});

builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
});


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
        new CultureInfo("hr-BA")
     };
     opt.DefaultRequestCulture = new RequestCulture("bs-Latn-BA");
     opt.SupportedCultures = supportedCultures;
     opt.SupportedUICultures = supportedCultures;
 });
builder.Services.AddHttpClient("Location", options => {
    options.BaseAddress = new Uri("http://api.ipstack.com");
});
builder.Services.AddScoped<IApiClientService, ApiClientService>();


builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddTransient<IEmailService, EmailService>();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  builder =>
					  {
						  builder.WithOrigins("https://localhost:7155",
											  "http://www.contoso.com");
					  });
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
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

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
//app.UseCors("AllowAnyCorsPolicy");
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
