using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshopBee.Implementation;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Interfaces;
using RenoshobeeAPI.Implementation.Customer_Address;
using RenoshobeeAPI.Interfaces.Customer_AddressInterfaces;
using RenoshopBee.Models;
using RenoshobeeAPI.Model;
using RenoshobeeAPI.Implementation;
using RenoshobeeAPI.Interfaces.CartInterfaces;
using RenoshobeeAPI.Interfaces.OrderInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1")));
builder.Services.AddTransient<IImageServices<Product>, ImageService>();
builder.Services.AddTransient<IImageServices<Customer>, CustomerImageServices>();
builder.Services.AddTransient<IDateServices<Product>, DateServices>();
builder.Services.AddTransient<IDateServices<Customer>, CustomertDateServices>();
builder.Services.AddTransient<IProductContext, ProductContextServices>();
builder.Services.AddTransient<ICustomerAddress, CustomerAddressServices>();
builder.Services.AddTransient<ICartServices,CartServices>();
builder.Services.AddTransient<IOrderServices,OrderServices>();

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
app.UseSession();
app.UseCookiePolicy();

app.MapControllers();

app.Run();
