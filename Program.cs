using Coding_Challenge.Data;
using Coding_Challenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Determine which connection string to use based on the environment
var environment = builder.Environment.IsDevelopment() ? "DefaultConnection" : "ProdDefaultConnection";
var connectionString = builder.Configuration.GetConnectionString(environment);

// Add DB context to the container.
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add CORS to the container with environment-specific policy.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", policy =>
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
}
else
{
    //builder.Services.AddCors(options =>
    //{
    //    options.AddPolicy("ProductionPolicy", policy =>
    //        policy.WithOrigins("https://your-production-domain.com")
    //              .AllowAnyMethod()
    //              .AllowAnyHeader());
    //});
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", policy =>
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
}

// Add Task Services to the container.
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coding Challenge API v1");
        c.RoutePrefix = string.Empty;
        c.DefaultModelsExpandDepth(-1); // Hides the schemas at the bottom of the page
    });

    // Use the CORS policy for development
    app.UseCors("AllowAllOrigins");
}
else
{
    // Use the CORS policy for production
    app.UseCors("ProductionPolicy");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
