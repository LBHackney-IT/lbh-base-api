using System;

namespace base_api.V1.Boundary
{
    public class HealthCheckResponse
    {
        public HealthCheckResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public readonly bool Success;
        public readonly string Message;
    }
}
