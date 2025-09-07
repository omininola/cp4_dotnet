using cp4.Models;
using cp4.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDatabaseSettings = cp4.Data.MongoDatabaseSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDatabaseSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var config = sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value;
    return new MongoClient(config.ConnectionString);
});

builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase(config.DatabaseName);
    return database.GetCollection<Book>(config.CollectionName);
});

builder.Services.AddSingleton<BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
