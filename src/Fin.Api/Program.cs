using Fin.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
string? connectionString = builder.Configuration.GetConnectionString("FinDbConnectionString");

builder.Services.AddDbContext<FinContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(FinContext).Assembly.FullName)));// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
