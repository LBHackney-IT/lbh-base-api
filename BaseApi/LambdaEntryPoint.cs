using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace BaseApi
{
    [ExcludeFromCodeCoverage]
    public class LambdaEntryPoint : APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>();
        }
    }
}
