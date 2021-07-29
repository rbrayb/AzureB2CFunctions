using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureB2CFunctions
{
    public static class DisplayName
    {
        [FunctionName("DisplayName")]
        [Produces("text/html")]

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name1 = "";
            string name2 = "";
            string result = "";

            try
            {
                name1 = req.Form["givenName"];
                name2 = req.Form["surname"];

                result = name1 + " " + name2;
            }

            catch (Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            return (ActionResult)new OkObjectResult(new ResponseContentString(result));
        }
    }
}
