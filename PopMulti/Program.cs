using Microsoft.EntityFrameworkCore;
using PopMulti.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR(); // For SignalR

builder.Services.AddDbContext<PopMultiDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PopMultiConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapHub<ScoreHub>("/scoreHub"); // For SignalR

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PopMulti}/{action=PopMulti}/{id?}")
    .WithStaticAssets();


app.Run();
