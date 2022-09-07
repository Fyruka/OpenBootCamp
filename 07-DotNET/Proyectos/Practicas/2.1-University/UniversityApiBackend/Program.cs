// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;
// 10. User Serilog to log Events
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 11. Config Serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console() // con esto le decimos que se escriba en la consola. 
        .WriteTo.Debug() // Para que se escriba en el Debug
        .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// 2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB"; // Utilizamos el mismo nombre que le hemos dado en el archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service of JWT Autorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// 4. Add Custom Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
// TODO: Add rest of services

// 8. Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9. Config Swagger to take care of Autorization of JWT
builder.Services.AddSwaggerGen( options =>
{
    //We define the security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme // Especificamos el tipo de autenticacion es de tipo "Beaer"
    {
        // Documentamos para que Swagger sepa que esquema de autorizacion tenemos
        Name = "Authorization",
        Type = SecuritySchemeType.Http, // Tipo de esquema o por donde viaja
        Scheme = "Bearer", // Esquema que utiliza nuestra autenticacion
        BearerFormat = "JWT", // Tipo de formato de nuestro Bearer token
        In = ParameterLocation.Header, // Donde va el Bearer token, en este caso en la cabecera
        Description = "JWT Authorization Header using Bearer Scheme" // Descripcion para Swagger
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement // Añadimos el requerimiento 
    {
        {
            new OpenApiSecurityScheme // Especificamos el esquema de seguridad
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
            new string[]{}
        }
    });
});

// 5. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

var supportedCultures = new[] { "en-US", "es-ES" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// 12. Tell app to use Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
