using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi
{
    public static class HttpHeadersExtensions
    {
        /// <summary>
        /// Retrieves the named header value from the HttpHeaders collection.
        /// If the header value is actually a composite value, then the first
        /// part is returned.
        /// </summary>
        /// <param name="headers">The HttpHeaders collection</param>
        /// <param name="key">The name of the header requested</param>
        /// <returns>The required value or null</returns>
        public static string GetHeaderValue(this IHeaderDictionary headers, string key)
        {
            if (headers is null)
                throw new ArgumentNullException(nameof(headers));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (headers.TryGetValue(key, out StringValues val))
                return val.FirstOrDefault();
            else
                return default(string);
        }
    }
}
