using BlogManagement.Data;
using BlogManagement.Services.Contracts;
using BlogManagement.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using BlogManagement.Repositories.Contracts;
using BlogManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BlogManagement.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();



builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IService, Service>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
