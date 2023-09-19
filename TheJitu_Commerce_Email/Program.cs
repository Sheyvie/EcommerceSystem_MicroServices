using Azure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Email.Data;
using TheJitu_Commerce_Email.Extensions;
using TheJitu_Commerce_Email.Messaging;
using TheJitu_Commerce_Email.Services;

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
// To adjust db context for Singleton
var dBContextBuilder = new DbContextOptionsBuilder<AppDbContext>();

builder.Services.AddSingleton(new EmailServices(dBContextBuilder.Options));

builder.Services.AddSingleton<IAzureMessageBusConsumer, AzureMessageBusConsumer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMigration();
app.useAzure();
app.UseMigration();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
