using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Cart.Data;
using TheJitu_Commerce_Cart.Extensions;
using TheJitu_Commerce_Cart.Services;
using TheJitu_Commerce_Cart.Services.Iservices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//connection to Db

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

//registering base urls for the services
builder.Services.AddHttpClient("Product", c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ProductApi"]));
builder.Services.AddHttpClient("Coupon", c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:CouponApi"]));

//register Services
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ICouponInterface, CouponService>();

//Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//custom builders

builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}
app.UseMigration();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
