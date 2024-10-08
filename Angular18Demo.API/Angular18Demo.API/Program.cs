using Angular18Demo.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // URL of your Angular app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure SQL Server connection
builder.Services.AddDbContext<databaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
