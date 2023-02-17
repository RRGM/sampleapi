using sampleapi.Configuration;
using sampleapi.Interfaces;
using sampleapi.Services;

var builder = WebApplication.CreateBuilder(args);
var configSection = builder.Configuration.GetSection("SwapiOptions");
builder.Services.Configure<SwapiOptions>(configSection);
var swapiOptions = configSection.Get<SwapiOptions>();
// Add services to the container.
builder.Services.AddHttpClient<IPeopleService, PeopleService>(c => 
                                c.BaseAddress = new Uri(swapiOptions.People.BaseUrl));
builder.Services.AddHttpClient<IPlanetService, PlanetService>(c => 
                                c.BaseAddress = new Uri(swapiOptions.Planet.BaseUrl));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
