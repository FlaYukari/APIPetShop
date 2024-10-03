using Microsoft.OpenApi.Models;
using PetShop.Filters;

namespace PetShop.Configurations
{
    public static class SwaggerConfigurations
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API PetShop",
                    Version = "v1"
                });

                c.SchemaFilter<DateTimeSchemaFilter>();

                // Configurações adicionais, como segurança, se necessário
                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     In = ParameterLocation.Header,
                //     Description = "Insira o token JWT Bearer",
                //     Name = "Authorization",
                //     Type = SecuritySchemeType.ApiKey
            });

            // c.AddSecurityRequirement(new OpenApiSecurityRequirement
            // {
            //     { new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //             }
            //         },
            //         new string[] {}
            //     }
            // });
        }


        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API PetShop V1");
                //c.RoutePrefix = string.Empty; // Para acessar na raiz do projeto
            }
            );
        }
    }
}

