using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSkillProfi.AuthApp;
using WebSkillProfi.Data;
using WebSkillProfi.DataContext;
using WebSkillProfi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection" ??
        throw new InvalidOperationException("Строка подключения 'DefaultConnection' не найдена.")));
});

builder.Services.AddTransient<IRequestData, RequestDataApi>();
builder.Services.AddTransient<IServiceData, ServiceDataApi>();
builder.Services.AddTransient<IProjectData, ProjectDataApi>();
builder.Services.AddTransient<IContactData, ContactDataApi>();
builder.Services.AddTransient<IBlogData, BlogDataApi>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5; 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.SlidingExpiration = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
