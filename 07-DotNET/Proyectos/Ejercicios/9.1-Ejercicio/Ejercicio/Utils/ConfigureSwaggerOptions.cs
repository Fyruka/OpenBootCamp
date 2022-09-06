using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ejercicio.Utils
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "My .Net Apit Restful for Exersice",
                Version = description.ApiVersion.ToString(),
                Description = "This is my second API Versioning control",
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
            foreach ( var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
