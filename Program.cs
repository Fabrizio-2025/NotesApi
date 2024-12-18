using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Repositories;
using NotesApi.Repositories.Implementations;
using NotesApi.Services;
using NotesApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// ========================
// Configuración de Servicios
// ========================

// Configuración del DbContext con PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseNpgsql(connectionString));

// Inyección de dependencias para Repositorios y Servicios
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITypeRepository, TypeRepository>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITypeService, TypeService>();

// Configuración de controladores
builder.Services.AddControllers();

// Configuración de Swagger (Documentación OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ========================
// Construcción de la aplicación
// ========================
var app = builder.Build();

// ========================
// Configuración del Middleware
// ========================

// Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección HTTPS
app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();

// ========================
// Ejecutar la aplicación
// ========================
app.Run();