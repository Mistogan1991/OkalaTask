using Api.Config;
using Api.ExternalServices;
using Api.Interfaces;
using Api.Middleware;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<CoinMarketCapApiSettings>(builder.Configuration.GetSection("CoinMarketCapSettings"));

var settings = builder.Configuration.GetSection("CoinMarketCapSettings").Get<CoinMarketCapApiSettings>();
builder.Services.AddHttpClient<ICoinMarketCapService, CoinMarketCapService>(client =>
{
    var settings = builder.Configuration.GetSection("CoinMarketCapSettings").Get<CoinMarketCapApiSettings>();
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.Configure<ExchangeRateSettings>(builder.Configuration.GetSection("ExchangeRateSettings"));
builder.Services.AddHttpClient<IExchangeRatesService, ExchangeRatesService>(client =>
{
    var settings = builder.Configuration.GetSection("ExchangeRateSettings").Get<ExchangeRateSettings>();
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddScoped<ICryptoService, CryptoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();
