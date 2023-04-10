using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshopBee.Implementation;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1")));
builder.Services.AddTransient<IProductImage, ProductImageService>();
builder.Services.AddTransient<IProductDate, ProductDateServices>();
builder.Services.AddTransient<IProductContext, ProductContextServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
