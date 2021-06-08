using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using BRIT.DevTest.Function.Service.Exceptions;
using BRIT.DevTest.Function.Service.Handlers.InstructionCalculatorRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace BRIT.DevTest.Function
{
    public class InstructionCalculatorFunction
    {
        public InstructionCalculatorFunction(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        [FunctionName("InstructionCalculatorFunction")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: MediaTypeNames.Application.Json, bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                //sanitize
                requestBody = requestBody.Trim('\r', '\n');
                var request = new InstructionCalculatorRequest(requestBody);

                var response = await Mediator.Send(request);

                return new OkObjectResult(response.Output);
            }
            catch (InstructionFormatException ex)
            {
                log.LogWarning(ex.Message, ex);

                return new BadRequestObjectResult(
                    new ProblemDetails() { 
                        Title = HttpStatusCode.BadRequest.ToString(),
                        Status = (int?)HttpStatusCode.BadRequest,
                        Detail = ex.Message,
                        Type = $"https://httpstatuses.com/{(int)HttpStatusCode.BadRequest}"
                    });
            }
            catch(Exception ex)
            {
                log.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}

