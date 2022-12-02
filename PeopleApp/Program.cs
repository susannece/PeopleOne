using Microsoft.EntityFrameworkCore;
using PeopleApp.Data;
using PeopleApp.Models.Repos;
using PeopleApp.Models.Services;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext to ConfigureServices
builder.Services.AddDbContext<PeopleAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>(); // IoC & DI
builder.Services.AddScoped<IPeopleService, PeopleService>();  // IoC & DI
builder.Services.AddScoped<IPeopleRepo, DatabasePeopleRepo>(); // IoC & DI

builder.Services.AddScoped<ICityService, CityService>();  // IoC & DI
builder.Services.AddScoped<ICityRepo, DatabaseCityRepo>(); // IoC & DI

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
