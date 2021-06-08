using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MediatR;
using BRIT.DevTest.Function;
using BRIT.DevTest.Function.Service.Handlers.InstructionCalculatorRequest;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BRIT.DevTest.Function.Service.Mappers;
using BRIT.DevTest.Function.Service.Parser;
using Hellang.Middleware.ProblemDetails;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BRIT.DevTest.Function.Service.Exceptions;
using Microsoft.AspNetCore.Hosting;

[assembly: FunctionsStartup(typeof(Startup))]
namespace BRIT.DevTest.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(typeof(InstructionCalculatorRequestHandler).GetTypeInfo().Assembly);

            builder.Services.AddSingleton<IInstructionMapper, InstructionMapper>();
            builder.Services.AddSingleton<IInstructionParser, InstructionParser>();
        }
    }
}
