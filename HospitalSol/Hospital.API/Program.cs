using Autofac;
using Hospital.Abstraction.Interfaces;
using Hospital.API;
using Hospital.BL.Doctor;
using Hospital.BL.Patient;
using Hospital.DAL;
using Hospital.DAL.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
var config = new TypeAdapterConfig();
builder.Services.AddSingleton(config);
builder.Services.AddSingleton<IMapper, ServiceMapper>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
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

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new Hospital.BL.Module()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        DbInitializer.Seed(context, logger);
    }
    catch (Exception e)
    {
        logger.LogError(e, "Error migration");
        //Console.WriteLine(e);
    }
}

app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();