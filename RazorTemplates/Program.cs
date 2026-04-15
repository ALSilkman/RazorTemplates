using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using RazorTemplates.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddSession();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TicketContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TicketContext")));

builder.Services.AddDbContext<CountryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/game-{activeGame}/cate-{activeCate}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
