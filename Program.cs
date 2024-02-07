using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
//using RashakaGroupsAdmin.Data;
//using RashakaGroupsAdmin.Models;
//using RashakaGroupsAdmin.Repository.Interfaces;
//using RashakaGroupsAdmin.Repository.UniteOfWork;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using RashakaAdmin.Models;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DapperConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#region MyRegion
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
});

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//IHttpContextAccessor register
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{      // Cookie settings
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/users/Login/";
    options.AccessDeniedPath = "/error/unauthorized";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;
});
#endregion
//builder.Services.AddAuthentication("auth")
//            .AddCookie("auth", config =>
//            {
//                config.Cookie.Name = "cookie.name";
//                config.LoginPath = "/users/login";
//            });



builder.Services.AddDbContext<RashakaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DapperConnectionString")));
builder.Services.AddScoped<IRashakaUniteOfWork, RashakaUniteOfWork>();
builder.Services.AddScoped<IAdminUsers, AdminUsers>();
builder.Services.AddScoped<INotification, NotificationService>();
builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<IGroupPost, GroupPostService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IGroupUser, GroupUsersService>();
builder.Services.AddScoped<IimagesSevice, ImagesSevice>();
builder.Services.AddScoped<IGroupSteps, GroupStepsService>();
builder.Services.AddScoped<ICommentSystemService, CommentSystemService>();




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

//app.UseHttpsRedirection();
app.UseStaticFiles();
const int durationInSeconds = 60 * 60 * 24 * 365;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "/wwwroot",
    ServeUnknownFileTypes = false,
    OnPrepareResponse = ctx =>
    {
        var headers = ctx.Context.Response.GetTypedHeaders();
        ctx.Context.Response.GetTypedHeaders().CacheControl =
         new CacheControlHeaderValue()
         {
             Public = true,
             MaxAge = TimeSpan.FromSeconds(durationInSeconds),
         };
        //string path = ctx.File.PhysicalPath;
        ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={durationInSeconds}");
        ctx.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddYears(1).ToString("R") }); // Format RFC1123
        ctx.Context.Response.Headers.Append("Content-Encoding", "gzip");
    }
});

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
