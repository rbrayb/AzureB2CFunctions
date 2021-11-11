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
        [Produces("application/json")]

        public static ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int iNum1 = 0;
            int iNum2 = 0;

            String num1 = "";
            String num2 = "";
            
            string comparison;
            bool compResult;
            
            try
            {
                num1 = req.Query["num1"];
                num2 = req.Query["num2"];
                comparison = req.Query["comparison"];

                iNum1 = System.Int32.Parse(num1);
                iNum2 = System.Int32.Parse(num2);

                if (comparison.ToLower().Equals("eq"))
                {
                    if (iNum1 == iNum2)
                        compResult = true;
                    else
                        compResult = false;
                }
                else if (comparison.ToLower().Equals("lt"))
                {
                    if (iNum1 < iNum2)
                        compResult = true;
                    else
                        compResult = false;
                }
                else if (comparison.ToLower().Equals("gt"))
                {
                    if (iNum1 > iNum2)
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
                return new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            return new OkObjectResult(new ResponseContentBool(compResult));

        }
    }
}
