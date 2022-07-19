using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdventOfCode.Controllers
{
    public class ParameterFilter: IParameterFilter
    {    
        public ParameterFilter(){}

        public void Apply(OpenApiParameter parameter, ParameterFilterContext context){
            if (parameter.Name.Equals("day", StringComparison.InvariantCultureIgnoreCase)){
                List<int> daysInDecember = Enumerable.Range(1, 31).ToList();
                parameter.Schema.Enum = daysInDecember.Select(d => new OpenApiString(d.ToString())).ToList<IOpenApiAny>();
            }

            if (parameter.Name.Equals("year", StringComparison.InvariantCultureIgnoreCase)){
                // Server time is UTC-5
                DateTime now = DateTime.UtcNow.AddHours(-5);
                int latestPuzzleYear = now.Year - (now.Month == 12 ? 0 : 1);

                List<int> daysInDecember = Enumerable.Range(2015, (latestPuzzleYear - 2015) + 1).ToList();
                parameter.Schema.Enum = daysInDecember.Select(d => new OpenApiString(d.ToString())).ToList<IOpenApiAny>();
            }
        }
    }
}