using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;
using MyCompany.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("Project", new Config());
builder.Services.AddTransient<INewsItemsRepository, EFNewsItemsRepository>();
builder.Services.AddTransient<DataManager>();




builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "newsTestProjectAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});



//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews(x => { x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea")); }).AddDataAnnotationsLocalization()
    .AddViewLocalization(); ;

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

    options.DefaultRequestCulture = new RequestCulture("ru");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();


}

app.UseHttpsRedirection();

app.UseRequestLocalization();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();




//app.MapGet("/", async context => await context.Response.WriteAsync("Hello"));
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
