using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace base_api.Versioning
{
    public static class ApiVersionDescriptionExtensions
{
    public static string GetFormattedApiVersion(this ApiVersionDescription apiVersionDescription)
    {
        return $"v{apiVersionDescription.ApiVersion.ToString()}";
    }
}
}

