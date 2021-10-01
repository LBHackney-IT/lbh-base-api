using AspectInjector.Broker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Logging
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [Injection(typeof(LogCallAspect))]
    public class LogCallAttribute : Attribute
    {
        public LogLevel Level { get; set; } = LogLevel.Trace;
        public LogCallAttribute() { }
        public LogCallAttribute(LogLevel level)
        {
            Level = level;
        }
    }
}
