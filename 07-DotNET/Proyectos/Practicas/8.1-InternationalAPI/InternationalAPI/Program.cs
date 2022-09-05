var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// 1. FILES LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources"); // Añadimos la localizacion de la carpeta que contendra los archivos de traduccion. 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. SUPPORTED CULTURES
var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; // US English - Spain Spanish - France French
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])    // English by Default
    .AddSupportedCultures(supportedCultures)    // Add all supported cultures
    .AddSupportedUICultures(supportedCultures); // Add supported cultures to UI

// 3. ADD LOCALIZATION to APP
app.UseRequestLocalization(localizationOptions); // A partir de este momento nuestra aplicacion puede recibir parametros dentro de una consulta para determinar la localizacion. 

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
