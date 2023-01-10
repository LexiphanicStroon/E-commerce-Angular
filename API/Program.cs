using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
// using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



            // builder.Services.AddAutoMapper(typeof(MappingProfiles));
            // builder.Services.AddControllers();
            // builder.Services.AddDbContext<StoreContext>(x =>
            //     x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            // builder.Services.AddDbContext<AppIdentityDbContext>(x => 
            // {
            //     x.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection"));
            // });

            // builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
            // {
            //     var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
            //     return ConnectionMultiplexer.Connect(configuration);
            // });
            // builder.Services.AddApplicationServices();
            // builder.Services.AddIdentityServices(builder.Configuration);
            // builder.Services.AddSwaggerDocumentation();
            // builder.Services.AddCors(opt =>
            // {
            //     opt.AddPolicy("CorsPolicy", policy =>
            //     {
            //         policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            //     });
            // });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
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

app.Run();
