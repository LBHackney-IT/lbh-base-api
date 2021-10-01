using AspectInjector.Broker;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BaseApi.V1.Logging
{
    [Aspect(Scope.PerInstance, Factory = typeof(LogCallAspectServices))]
    public class LogCallAspect
    {
        private readonly ILogger<LogCallAspect> _logger;

        public LogCallAspect(ILogger<LogCallAspect> logger)
        {
            _logger = logger;
        }

        private static LogLevel GetLevel(Attribute[] attributes)
        {
            var level = LogLevel.Trace;
            var attribute = attributes.OfType<LogCallAttribute>().FirstOrDefault();
            if (null != attribute)
                level = attribute.Level;
            return level;
        }

        [Advice(Kind.Before, Targets = Target.Method)]
        public void LogEnter([Argument(Source.Type)] Type type, [Argument(Source.Name)] string name,
            [Argument(Source.Triggers)] Attribute[] triggers)
        {
            _logger.Log(GetLevel(triggers), $"STARTING {type.Name}.{name} method");
        }

        [Advice(Kind.Before, Targets = Target.Method)]
        public void LogExit([Argument(Source.Type)] Type type, [Argument(Source.Name)] string name,
            [Argument(Source.Triggers)] Attribute[] triggers)
        {
            _logger.Log(GetLevel(triggers), $"ENDING {type.Name}.{name} method");
        }
    }
}
