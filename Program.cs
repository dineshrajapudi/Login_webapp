using Microsoft.EntityFrameworkCore;
using WebApplication_Login.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();
ConfigurationManager config = builder.Configuration;
string? custvalue1 = builder.Configuration["CustomKey1"];
string? custvalue2 = builder.Configuration["CustomKey2"];
app.MapGet("/custom", () => $"{custvalue1} & {custvalue2}");

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
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NotHome}/{action=Zoo}/{id?}");

app.Run();
