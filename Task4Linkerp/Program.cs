using AdminSiteUseMVC;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NuGet.Protocol.Core.Types;
using System.Globalization;
using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnectionstring")));
builder.Services.AddScoped<IBookRepository , BookRepository>();
builder.Services.AddScoped<IBorrowerRepository , BorrowerRepository>();
builder.Services.AddScoped<IBorrowedRepository , BorrowedRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
//builder.Services.AddScoped<IBorrowerRepository, BorrowerRepository>();
//builder.Services.AddScoped<IBorrowedRepository,BorrowedRepository>();

///////////////////Localization//////////
builder.Services.AddLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(JsonStringLocalizerFactory));
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG")
    };

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

var supportedCultures = new[] { "en-US", "ar-EG" };
var localizationOptions = new RequestLocalizationOptions()
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
