using GFA.Application.Services.ContactService;
using GFA.Application.Services.ProfileService;
using GFA.Application.Services.ShootService;
using GFA.Application.Services.SocialService;
using GFA.Application.Services.TagService;
using GFA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ISocialsService, SocialsService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IShootService, ShootService>();

builder.Services.AddCors(options => options.AddPolicy(
    name: "AllowLocalhost",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000").WithOrigins("http://localhost:5000").AllowAnyMethod().AllowAnyHeader();
    }
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
