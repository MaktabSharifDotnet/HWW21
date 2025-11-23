using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Contracts.AuthorAgg.Repository;
using App.Domain.Core.Contracts.AuthorAgg.Service;
using App.Domain.Services.AuthorAgg;
using App.Infra.Data.Repos.Ef.AuthorAgg;
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
