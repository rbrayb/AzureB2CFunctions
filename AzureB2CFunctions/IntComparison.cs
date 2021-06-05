using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureB2CFunctions
{
    public static class IntComparison
    {
        [FunctionName("IntComparison")]
        [Produces("text/html")]

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int num1 = 0;
            int num2 = 0;
            string comparison;
            bool compResult;

            try
            {
                num1 = Int32.Parse(req.Form["num1"]);
                num2 = Int32.Parse(req.Form["num2"]);
                comparison = req.Form["comparison"];

                if (comparison.ToLower().Equals("eq"))
                {
                    if (num1 == num2)
                        compResult = true;
                    else
                        compResult = false;
                }
                else if (comparison.ToLower().Equals("lt"))
                {
                    if (num1 < num2)
                        compResult = true;
                    else
                        compResult = false;
                }
                else if (comparison.ToLower().Equals("gt"))
                {
                    if (num1 > num2)
                        compResult = true;
                    else
                        compResult = false;
                }
                else
                {
                    return (ActionResult)new ConflictObjectResult(new ResponseContent("Invalid comparison - must be eq/lt/gt", 409));
                }

            }

            catch (Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            return (ActionResult)new OkObjectResult(new ResponseContentBool(compResult));
        }
    }
}
