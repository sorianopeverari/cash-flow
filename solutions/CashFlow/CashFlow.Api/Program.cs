using CashFlow.Domain.Repositories;
using CashFlow.Infra.Repositories.PgDW;
using CashFlow.Infra.Repositories.PgRDS;
using CashFlow.Domain.Business;
using Microsoft.FeatureManagement;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITransactionBusiness, TransactionBusiness>();
builder.Services.AddTransient<IBalanceBusiness, BalanceBusiness>();
builder.Services.AddTransient<ITransactionRepository, TransactionPgRDSRepository>();
builder.Services.AddTransient<IBalanceRepository, BalancePgDWRepository>();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();