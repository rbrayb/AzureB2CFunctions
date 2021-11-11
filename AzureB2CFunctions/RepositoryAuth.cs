using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureB2CFunctions
{
    public static class RepositoryAuth
    {
        [FunctionName("RepositoryAuth")]
        [Produces("text/html")]

        public static ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string userName = String.Empty;
            string password = String.Empty;

            try
            {
                userName = req.Query["userName"];
                password = req.Query["password"];               
            }

            catch (Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent(ex.ToString(), 409));
            }

            if (String.IsNullOrEmpty(userName))
            {
                // return (ActionResult)new ConflictObjectResult(new ResponseContent("Null userName", "1234", "409", "0987654", "userName is null", "https://info"));
                return (ActionResult)new ConflictObjectResult(new ResponseContent("Null userName", 409));
            }

            if (String.IsNullOrEmpty(password))
            {
                //return (ActionResult)new ConflictObjectResult(new ResponseContent("Null password", "5678", "409", "086420", "Password is null", "https://info"));
                return (ActionResult)new ConflictObjectResult(new ResponseContent("Null password", 409));
            }

            if (password.Equals("password"))
            {
                return (ActionResult)new OkObjectResult(new ResponseContentJWT());
            }
            else
            {
                // return (ActionResult)new ConflictObjectResult(new ResponseContent("Invalid credentials", "409"));
                return (ActionResult)new ConflictObjectResult(new ResponseContent("Invalid credentials", 409, "API12345", "50f0bd91-2ff4-4b8f-828f-00f170519ddb", "Credentials are incorrect",
                   "https://info/api/API12345"));
                // return (ActionResult)new ConflictObjectResult(new ResponseContent("Invalid credentials", 409));
                // return (ActionResult)new ConflictObjectResult(new ResponseContent("Invalid credentials", 409, "API12345"));
            }            
            
        }
    }
}
