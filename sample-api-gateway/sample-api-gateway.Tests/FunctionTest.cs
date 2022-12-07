using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;

namespace sample_api_gateway.Tests;

public class FunctionTest
{
    [Fact]
    public async Task TestSampleFunction()
    {
        var function = new Function();
        var context = new TestLambdaContext();
        var request = new APIGatewayProxyRequest();
        var response = await function.FunctionHandler(request, context);

        Assert.Equal(200, response.StatusCode);
        Assert.Contains("Hello World from Lambda", response.Body);
    }
}