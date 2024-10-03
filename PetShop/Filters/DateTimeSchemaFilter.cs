using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PetShop.Filters
{
    public class DateTimeSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(DateTime?) || context.Type == typeof(DateTime))
            {
                schema.Example = new OpenApiString("yyyy-MM-dd"); // Exemplo de formato
            }
        }
    }
}
