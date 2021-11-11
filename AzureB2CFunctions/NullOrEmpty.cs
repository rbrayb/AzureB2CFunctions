using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureB2CFunctions
{
    public static class NullOrEmpty
    {
        [FunctionName("NullOrEmpty")]
        [Produces("text/html")]

        public static ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name1 = "";           
            bool result = false;

            try
            {
                name1 = req.Form["claimName"];

                if (String.IsNullOrEmpty(name1))
                    result = true;
            }

            catch (Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            return (ActionResult)new OkObjectResult(new ResponseContentBool(result));
        }
    }
}
