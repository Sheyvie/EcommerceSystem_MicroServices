using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Products.Data;
using TheJitu_Commerce_Products.Extensions;
using TheJitu_Commerce_Products.Services;
using TheJitu_Commerce_Products.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
//register service
builder.Services.AddScoped<IProductsInterface, ProductService>();

//register automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//add custom services
builder.AddAppAuthentication();
builder.AddSwaggenGenExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
