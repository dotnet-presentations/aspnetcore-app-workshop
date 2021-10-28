var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSqlServer<ApplicationDbContext>("name=DefaultConnection")
        .AddDatabaseDeveloperPageExceptionFilter();

services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

services.AddHealthChecks()
        .AddDbContextCheck<ApplicationDbContext>();

services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new () { Title = "Conference Planner API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Planner API v1");
});

app.MapControllers();
app.MapHealthChecks("/health");
app.MapFallback(() => Results.Redirect("/swagger"));

app.Run();