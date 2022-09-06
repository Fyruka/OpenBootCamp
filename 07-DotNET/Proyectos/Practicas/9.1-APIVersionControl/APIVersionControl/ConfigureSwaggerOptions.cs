using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIVersionControl
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions> // Esto trae una interface que Visual Studio nos genera automaticamente si dejamos el raton en el nombre.
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description) // Creamos la informacion para la descripcion de nuestra API RESTful
        {
            var info = new OpenApiInfo()
            {
                Title = "My .Net Apit Restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API Versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "samuel@admin.com",
                    Name = "Samuel"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version is deprecated";
            }

            return info;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Add Swagger Docuemntation for each API version we have
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description)); // Esto creara un bloque de descripcion dentro del Swagger doc que se generan para informar al cliente de los cambios que han habido
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        
    }
}
