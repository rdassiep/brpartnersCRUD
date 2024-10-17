using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using brpartnersCRUD.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BrpartnersCRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("brpartnersCRUDContext") ?? throw new InvalidOperationException("Connection string 'brpartnersCRUDContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BrpartnersCRUDContext>();
    context.Database.EnsureCreated(); // This will create the database if it doesn't exist
    
}

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
