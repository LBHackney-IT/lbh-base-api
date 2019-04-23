using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace base_api.Versioning
{
    public static class ApiVersionExtensions
    {
        public static string GetFormattedApiVersion(this ApiVersion apiVersion)
        {
            return $"v{apiVersion.ToString()}";
        }
    }
}
