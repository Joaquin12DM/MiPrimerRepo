using Microsoft.EntityFrameworkCore;
using EntityLayer;
using DomainLayer;
using DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDbexamenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnx")));



// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<ReservaRepository>();
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
