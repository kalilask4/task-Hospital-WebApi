using Hospital.API;
using Hospital.DAL;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new TypeAdapterConfig();

builder.Services.AddSingleton(config);
builder.Services.AddSingleton<IMapper, ServiceMapper>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        "name=ConnectionStrings:SqlServerConnectionString", 
        optionsBuilder => optionsBuilder.MigrationsAssembly("Hospital.DAL"));
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine);
    
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

//app.UseAuthorization();

using (var serviceScope = app.Services.CreateScope())
{
    try
    {
        var services = serviceScope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();
        context.Database.Migrate();
        DbInitializer.Seed(context, logger);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

}

app.MapControllers();

app.Run();