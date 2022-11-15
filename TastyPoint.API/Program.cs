using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TastyPoint.API.Selling.Domain.Repositories;
using TastyPoint.API.Selling.Domain.Services;
using TastyPoint.API.Selling.Persistence.Repositories;
using TastyPoint.API.Selling.Services;
using TastyPoint.API.Shared.Domain.Repositories;
using TastyPoint.API.Shared.Persistence.Contexts;
using TastyPoint.API.Shared.Persistence.Repositories;
using TastyPoint.API.Subscription.Domain.Repositories;
using TastyPoint.API.Subscription.Domain.Services;
using TastyPoint.API.Subscription.Persistence.Repositories;
using TastyPoint.API.Subscription.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//Add Lowercase Routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Selling Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IPackRepository, PackRepository>();
builder.Services.AddScoped<IPackService, PackService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBusinessPlanRepository, BusinessPlanRepository>();
builder.Services.AddScoped<IBusinessPlanService, BusinessPlanService>();

//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(TastyPoint.API.Selling.Mapping.ModelToResourceProfile),
    typeof(TastyPoint.API.Selling.Mapping.ResourceToModelProfile),
    typeof(TastyPoint.API.Subscription.Mapping.ModelToResourceProfile),
    typeof(TastyPoint.API.Subscription.Mapping.ResourceToModelProfile));

builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Tasty Point API",
            Description = "Tasty Point Restfull API",
            TermsOfService = new Uri("http://TastyPoint/TermsOfService"),
            Contact = new OpenApiContact
            {
                Name = "Tasty Point Studio",
                Url = new Uri("https://tastypoint-appweb.web.app/")
            },
            License = new OpenApiLicense
            {
                Name = "Tasty Point Resources Licenses",
                Url = new Uri("http://TastyPoint/Licenses")
            }
        });
        options.EnableAnnotations(); 
    }
);


var app = builder.Build();

//Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();