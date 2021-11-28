using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using crystalClean.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.GetConnectionString("CrystalCleanContext");
builder.Services.AddDbContext<CrystalCleanContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrystalCleanContext"))
    .UseLowerCaseNamingConvention();
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
// Learn more about configuring Swagger/OpenAPI 
// at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

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

// Enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

//dotnet ef dbcontext scaffold "Host=localhost;Database=CrystalClean;Username=valeriy;Password=valeriyk1" Npgsql.EntityFrameworkCore.PostgreSQL
