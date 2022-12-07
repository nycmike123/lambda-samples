using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace sample_api_gateway;

public class Function
{

    /*public async Task<APIGatewayProxyResponse> Process(APIGatewayProxyRequest request, ILambdaContext context)*/
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {

        var response = new APIGatewayProxyResponse
        {
            StatusCode = 200,
            
            IsBase64Encoded = false
        };

        await Task.Delay(1000);


        response.Headers = new Dictionary<string, string>
        {
            {"Content-Type", "text/html; charset=utf-8" }
        };

        response.Body =
@"
<html>
    <head>
        <title>Hello World!</title>
        <style>
            html, body {
                margin: 0; padding: 0;
                font-family: arial; font-weight: 700; font-size: 3em;
                text-align: center;
            }
        </style>
    </head>
    <body>
        <p>Hello World from Lambda</p>
    </body>
</html>
";

        return response;
    }
}