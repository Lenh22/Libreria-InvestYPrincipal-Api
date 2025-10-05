using Microsoft.EntityFrameworkCore;
using Libreria_InvestYPrincipal_Api.Data;
using Libreria_InvestYPrincipal_Api.Services;
using System.Text.Json.Serialization; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {//Para ciclos
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Services
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebForms", policy =>
    {
        policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowWebForms");

app.UseAuthorization();

app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    SeedData.Initialize(context);
}

app.Run();
