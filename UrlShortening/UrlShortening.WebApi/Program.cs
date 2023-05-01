using Microsoft.EntityFrameworkCore;
using UrlShortening.Data.Contexts;
using UrlShortening.Domain.Interfaces;
using UrlShortening.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UrlsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("UrlShortening.Data")));

builder.Services.AddTransient<IUrlService, UrlService>();
builder.Services.AddTransient<UrlsDbContext, UrlsDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UrlsDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
