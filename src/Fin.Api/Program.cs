using Fin.Api.Config;
using Fin.Data;
using Fin.Domain;
using Fin.Domain.CQRS.Commands.CreateUser;
using Fin.Domain.Interfaces;
using Fin.Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



Configure();

// Add services to the container.
builder.Services.AddControllers();

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


void Configure()
{
    string? connectionString = builder.Configuration.GetConnectionString("FinDbConnectionString");

    builder.Services.AddDbContext<FinContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(FinContext).Assembly.FullName)));// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IWalletRepository, WalletRepository>();
    builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
    builder.Services.AddScoped<IDispatcher, Dispatcher>();
    builder.Services.AddCqrsHandlers(typeof(CreateUserCommand).Assembly);
}