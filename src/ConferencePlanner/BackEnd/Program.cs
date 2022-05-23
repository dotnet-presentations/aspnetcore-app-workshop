using BackEnd.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
   ?? "Data Source=conferences.db";

builder.Services.AddSqlite<BackEnd.Data.ApplicationDbContext>(connectionString);
    
// Add services to the container.
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

app.MapSpeakerEndpoints();
app.MapAttendeeEndpoints();
app.MapSessionEndpoints();
app.MapSearchEndpoints();

app.Run();