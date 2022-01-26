global using App.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Here I can register my DI containers
builder.Services.AddSingleton<VarianService>();

builder.Services.AddCors(options =>
{
options.AddPolicy("CorsPolicy",
builder => builder
.AllowAnyMethod()
.AllowCredentials()
.SetIsOriginAllowed((host) => true)
.AllowAnyHeader());
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");



app.MapGet("/SecretService", (HttpContext ctx, VarianService service) => service.HelloVarianEmployee(ctx.Request.Query["firstname"].ToString()));




var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    // Here we could resolve EF Core context, but for now lets just generate weather collection

    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/", () => "This is the root of my backend app");

app.MapGet("/products/{id}", (string id) => "I love Hot Reload but please give me => " + id);

app.MapGet("/{id}", (string id) => "This is a GET ID => " + id);
app.MapPost("/", () => "This is a POST");
app.MapPut("/", () => "This is a PUT");
app.MapDelete("/", () => "This is a DELETE");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}