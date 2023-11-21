using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Configuration;
using docServer.Data;
using docServer.IRepository;
using docServer.Repository;
using docServer.Configurations;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

String mySqlConnectionStr = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<docServerContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


builder.Services.AddControllers();

//builder.Services.AddControllers().AddNewtonsoftJson(
//    op => op.SerializerSettings.ReferenceLoopHandling =
//    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocServer", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});


builder.Services.AddTransient<iUnitOfWorks, UnitOfWorks>();
//builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddSingleton(Serilog.Log.Logger);
builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));


// Logging
builder.Services.AddLogging();

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.File(
    path: "/Users/armah/Documents/SE Projects/docServer/docServer/logs/Log-.txt",
    
    
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{Level:u3}]{Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information));


builder.Services.AddAutoMapper(typeof(MapperInitialiser));
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();

});

app.MapControllers();
app.Run();

