using Microsoft.OpenApi.Models;

namespace Finanzauto.HuellaCarbono.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                //var jwtSecurityScheme = new OpenApiSecurityScheme
                //{
                //    Scheme = "bearer",
                //    BearerFormat = "JWT",
                //    Name = "JWT Authentication",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                //    Reference = new OpenApiReference
                //    {
                //        Id = JwtBearerDefaults.AuthenticationScheme,
                //        Type = ReferenceType.SecurityScheme
                //    }
                //};

                //options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    { jwtSecurityScheme, Array.Empty<string>() }
                //});

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "vl",
                    Title = "Huella de Carbono",
                    Description = "Un API desarrollada en ASP.NET Core para manejar calcular la Huella de carbono de los vehiculos.",
                });

                options.ResolveConflictingActions(apiDescription => apiDescription.First());
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });

            return services;
        }

    }
}
