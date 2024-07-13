using EventLogs_Management.Core.SQL;
using EventLogs_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Get Connection String
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<EventsLogsDBContext>();

// Set up Database
builder.Services.Configure<SQLSettings>(options => { options.ConnectionString = connectionString; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EventsLogsDBContext>();

    db.Database.EnsureDeleted();
    db.Database.Migrate();

    SeedDataDemo.Initialize(db);
}

app.Run();
