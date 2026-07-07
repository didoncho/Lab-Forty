using Business;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

///
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<ProductRepository>();

////Dependency Injection 
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/openapi/v1.json", "API v1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Minimal API: products
app.MapGet("/products", (ProductRepository repository) => repository.GetAll());

app.MapGet("/products/{id:int}", (int id, ProductRepository repository) =>
	repository.Get(id) is { } product ? Results.Ok(product) : Results.NotFound());

app.MapGet("/products/by-name/{name}", (string name, ProductRepository repository) =>
	repository.GetByName(name) is { } product ? Results.Ok(product) : Results.NotFound());

app.MapPut("/products/{id:int}", (int id, [FromBody] string newName, ProductRepository repository) =>
{
	repository.Update(id, newName);
	return Results.NoContent();
});

app.Run();
