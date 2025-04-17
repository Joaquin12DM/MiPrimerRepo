using Microsoft.EntityFrameworkCore;
using Practica2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDbexamenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnx")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Habitacion}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
