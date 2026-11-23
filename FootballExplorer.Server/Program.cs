using FootballExplorer.Server.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<FootballApiService>();

// Configure the Football-Data.org API connection.
var apiToken = builder.Configuration["FootballData:ApiToken"];

if (string.IsNullOrWhiteSpace(apiToken))
{
    throw new InvalidOperationException(
        "Football-Data.org API token is missing.");
}

builder.Services.AddHttpClient("FootballData", client =>
{
    client.BaseAddress = new Uri(
        "https://api.football-data.org/v4/");

    client.DefaultRequestHeaders.Add(
        "X-Auth-Token", apiToken);
});

// OpenAPI configuration.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
