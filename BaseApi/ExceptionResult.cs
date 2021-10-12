using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi
{
    public class ExceptionResult
    {
        public const int DefaultStatusCode = 500;

        private static JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public ExceptionResult(string message, string traceId, string correlationId, int statusCode = DefaultStatusCode)
        {
            Message = message;
            TraceId = traceId;
            CorrelationId = correlationId;
            StatusCode = statusCode;
        }

        public string Message { get; private set; }
        public string TraceId { get; private set; }
        public string CorrelationId { get; private set; }
        public int StatusCode { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, _settings);
        }
    }
}
