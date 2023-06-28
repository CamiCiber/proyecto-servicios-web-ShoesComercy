
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CustomerApp.Repository;
using System;
using AppCustomer.DbContexts;
using AppCustomer.Repository;
using AppCustomer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BDCustomer");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICustomerRepository, CustomerSQLRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
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

app.UseHttpsRedirection();
app.UseCors("MyAllowedOrigins");


app.UseAuthorization();

app.MapControllers();

app.Run();
