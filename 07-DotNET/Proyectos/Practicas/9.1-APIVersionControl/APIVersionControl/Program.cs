// 1. Nos traemos los using necesarios
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using APIVersionControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 2. Add HttpClient to send HttpRequests in controllers
builder.Services.AddHttpClient();

// 3. Add Versioning Control System
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0); // Version por defecto 1.0
    setup.AssumeDefaultVersionWhenUnspecified = true; // Si no viene version especificada en la consulta, que asuma la por defecto que en este caso seria la 1.0
    setup.ReportApiVersions = true; // Informar de las versiones de nuestra API
});

// 4. Add configuration to document version
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV"; // Como queremos que se escriba la verion, en este caso se vera como v1.0.0 
    setup.SubstituteApiVersionInUrl = true; // Sustituir la version en la URL, ya que en nuestro controlador hemos dejado ese hueco en la URL
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. Configure options
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>(); // Añadimos nuestras opciones de swagger al programa para que asi las reconozca

var app = builder.Build();

// 6. Configure Endpoints for Swagger DOCS for each of the versions of our API
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // 7. Configure Swagger DOCS
    app.UseSwaggerUI(options => // por cada version de nuestra API que tengamos, tendremos que añadirle a swagger una pagina distinta. Y que se genere la documentacion para cada version
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant()
                
            );
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
