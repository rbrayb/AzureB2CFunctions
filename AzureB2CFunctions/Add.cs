using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using HttpMultipartParser;

using System.IO;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public static class Add
    {
        [FunctionName("Add")]
        [Produces("application/json")]

        public static ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int iNum1 = 0;
            int iNum2 = 0;

            String num1 = "";
            String num2 = "";
            int result = 0;

            try
            {
                num1 = req.Query["num1"];
                num2 = req.Query["num2"];                

                iNum1 = System.Int32.Parse(num1);
                iNum2 = System.Int32.Parse(num2);

                result = iNum1 + iNum2;
            }

            catch (Exception ex)
            {
                return new OkObjectResult(new ResponseContent
                {
                    userMessage = ex.Message + " * " + ex.InnerException,
                    status = 409                    
                }); ;
            }

            return new OkObjectResult(new ResponseContentInt(result));
            
        }
    }
}
