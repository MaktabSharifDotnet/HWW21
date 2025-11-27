using App.Domain.AppServices.CategoryAgg;
using App.Domain.AppServices.CommentAgg;
using App.Domain.AppServices.PostAgg;
using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Contracts.AuthorAgg.Repository;
using App.Domain.Core.Contracts.AuthorAgg.Service;
using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.CategoryAgg.Repository;
using App.Domain.Core.Contracts.CategoryAgg.Service;
using App.Domain.Core.Contracts.CommentAgg.Repository;
using App.Domain.Core.Contracts.CommentAgg.Service;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.Repository;
using App.Domain.Core.Contracts.PostAgg.Service;
using App.Domain.Services.AuthorAgg;
using App.Domain.Services.CategoryAgg;
using App.Domain.Services.CommentAgg;
using App.Domain.Services.PostAgg;
using App.Infra.Data.Repos.Ef.AuthorAgg;
using App.Infra.Data.Repos.Ef.CategoryAgg;
using App.Infra.Data.Repos.Ef.CommentAgg;
using App.Infra.Data.Repos.Ef.PostAgg;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer("Server=DESKTOP-M2BLLND\\SQLEXPRESS;Database=HWW21;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IAuthorRepository , AuthorRepository>();
builder.Services.AddScoped<IAuthorService , AuthorService>();
builder.Services.AddScoped<IAuthorAppService , AuthorAppService>();
builder.Services.AddScoped<IAuthorAppService , AuthorAppService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();


builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();


builder.Services.AddScoped<ICommentRepository, CommnetRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
