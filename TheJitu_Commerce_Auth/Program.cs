using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Auth.Data;
using TheJitu_Commerce_Auth.Extensions;
using TheJitu_Commerce_Auth.Model;
using TheJitu_Commerce_Auth.Services;
using TheJitu_Commerce_Auth.Services.IService;
using TheJitu_Commerce_Auth.Utility;
using TheJituMessageApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to DB
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

//Register IdentityFramework
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


//RegisterServices
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IJWtTokenGenerator, JwtService>();
builder.Services.AddScoped<IMessageBus, MessageBus>();

//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Adding cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
   builder.WithOrigins("https://localhost:7263")
        .WithHeaders().
        AllowAnyMethod());

});


//configure JWtOptions 
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Run an Pending Migrations
app.UseMigration();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
