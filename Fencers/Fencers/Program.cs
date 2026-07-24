using DatabaseLayer;
using Fencers.Components;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	 .AddInteractiveServerComponents();

// DATABASE
builder.Services.AddDbContext<DataContext>();

// REPOSITORIES
builder.Services.AddScoped<CoachRepository>();
builder.Services.AddScoped<CompetitionFileRepository>();
builder.Services.AddScoped<CompetitionRepository>();
builder.Services.AddScoped<CompetitionResultRepository>();
builder.Services.AddScoped<FencerInformationRepository>();
builder.Services.AddScoped<FencerRepository>();

// SERVICES
builder.Services.AddScoped<CoachService>();
builder.Services.AddScoped<CompetitionFileService>();
builder.Services.AddScoped<CompetitionResultService>();
builder.Services.AddScoped<CompetitionService>();
builder.Services.AddScoped<FencerInformationService>();
builder.Services.AddScoped<FencerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
	 .AddInteractiveServerRenderMode();

app.Run();
