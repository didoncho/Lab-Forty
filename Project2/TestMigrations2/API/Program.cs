using System.Text.Json.Serialization;
using DatabaseLayer;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
	// Entities have bidirectional navigations (e.g. User <-> UserInformation),
	// so ignore reference cycles when serializing responses.
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// EF Core DbContext
builder.Services.AddDbContext<DataContext>();

// Repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserInformationRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderRepository>();

// Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserInformationService>();
builder.Services.AddScoped<ProductService>();
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

app.Run();
