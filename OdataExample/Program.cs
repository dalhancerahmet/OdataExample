using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using OdataExample;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(i => i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
    .AddOData(options =>
    {
        options.EnableQueryFeatures();// Bununla birlikte ODatanýn tüm özelliklerini/metotlarýný kullanabiliyoruz.
    });
builder.Services.AddDbContext<OdataContext>((sp, opt) =>
{
    opt.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=NORTHWND;Encrypt=False;Trusted_Connection=True;");
    opt.EnableSensitiveDataLogging();
});
//builder.Services.AddScoped<OdataContext,OdataContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
