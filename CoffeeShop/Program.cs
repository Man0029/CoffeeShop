using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(ShoppingCartRepository.GetCart);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddDbContext<CoffeeshopDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CoffeeshopDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CoffeeShopContext>();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

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
app.MapRazorPages();


app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
