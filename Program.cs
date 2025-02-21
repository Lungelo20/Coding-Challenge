using Coding_Challenge.Data;
using Coding_Challenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB context to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add CORS to the container.
//UPDATE FOR PRODUCTION - SHOULD NOT USE "AllowAllOrigins"
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add Task Services to the container.
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coding Challange API v1");
        c.RoutePrefix = string.Empty;
        c.DefaultModelsExpandDepth(-1); // Hides the schemas at the bottom of the page
    });
}

// Use the CORS policy for Dev, 
//UPDATE FOR PRODUCTION - - SHOULD NOT USE "AllowAllOrigins"
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
