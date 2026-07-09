using Microsoft.EntityFrameworkCore;
using Krydderverket.Data;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Configure Services
// ==========================================

builder.Services.AddControllers();

// Enable Swagger/OpenAPI support for API documentation and testing
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Configure CORS: Allow cross-origin requests from the frontend development server (Vite on port 5174)
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5174")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // 允许任何网址访问
              .AllowAnyMethod()   // 允许任何请求方式 (GET/POST)
              .AllowAnyHeader();  
    });
});

// Register the Database Context (DbContext) and read the connection string from appsettings.json

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseCors("AllowAll");

// ==========================================
// 2. Configure HTTP Request Pipeline (Middleware)
// ==========================================

// Enable Swagger UI only in the development environment
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.MapOpenApi();
}

// Enable CORS policy (Must be placed before UseAuthorization)
app.UseCors("ReactAppPolicy");

app.UseAuthorization();

// Automatically map controller routes (Enables access to endpoints like /api/products)
app.MapControllers();

app.Run();