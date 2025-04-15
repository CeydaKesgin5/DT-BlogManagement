using Services.Contracts;
using Services;
using BlogManagement.Services;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(options =>
//        {
//            options.LoginPath = "/Account/Login"; // Giriþ sayfasý
//            options.AccessDeniedPath = "/Account/AccessDenied"; // Yetki yoksa yönlendirme
//            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//        });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedInUser", policy => policy.RequireAuthenticatedUser());
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("BlogManagement"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";          // Giriþ sayfasý
    options.AccessDeniedPath = "/account/accessdenied";  // Yetki yoksa yönlendirme
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapStaticAssets();


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Blog}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}"
);


app.MapControllers();

app.Run();
