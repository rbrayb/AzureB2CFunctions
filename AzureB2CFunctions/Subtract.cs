using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureB2CFunctions
{
    public static class Subtract
    {
        [FunctionName("Subtract")]
        [Produces("text/html")]

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int num1 = 0;
            int num2 = 0;
            int result = 0;

            try
            {
                num1 = Int32.Parse(req.Form["num1"]);
                num2 = Int32.Parse(req.Form["num2"]);

                result = num1 - num2;
            }

            catch (Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            return (ActionResult)new OkObjectResult(new ResponseContentInt(result));
        }
    }
}
