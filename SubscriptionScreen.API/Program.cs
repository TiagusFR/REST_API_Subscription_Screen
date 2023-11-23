using SubscriptionScreen.API.Controllers.AutoMapper;
using SubscriptionScreen.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionScreen.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SubscriptionScreenAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubscriptionScreenAPIContext") ?? throw new InvalidOperationException("Connection string 'SubscriptionScreenAPIContext' not found.")));

// Add services to the container.
builder.Services.AddSingleton<SubscriptionDbContext>();
builder.Services.AddSingleton<UserDbContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

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
