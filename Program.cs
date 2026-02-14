using InventoryCore.Api.Data;
using InventoryCore.Api.Services;
using InventoryCore.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using InventoryCore.Api.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
    