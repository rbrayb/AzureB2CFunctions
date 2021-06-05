using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContent
    {
        public const string ApiVersion = "1.0.0";

        // Attribute            Required    Description

        // version              Yes         Your REST API version. For example: 1.0.1
        // status               Yes         Must be 409 if error
        // code                 No          An error code from the RESTful endpoint provider, which is displayed when DebugMode is enabled.
        // requestId            No          A request identifier from the RESTful endpoint provider, which is displayed when DebugMode is enabled.
        // userMessage          Yes         An error message that is shown to the user.
        // developerMessage     No          The verbose description of the problem and how to fix it, which is displayed when DebugMode is enabled.
        // moreInfo             No          A URI that points to additional information, which is displayed when DebugMode is enabled.

        public ResponseContent()
        {
            this.version = ResponseContent.ApiVersion;
            //this.status = HttpStatusCode.OK.ToString();
            this.userMessage = "OK";
        }

        public ResponseContent(string userMessage, int status)
        {
            this.version = ResponseContent.ApiVersion;
            this.userMessage = userMessage;
            this.status = status;
        }

        public ResponseContent(string userMessage, int status, string code)
        {
            this.version = ResponseContent.ApiVersion;
            this.userMessage = userMessage;
            this.status = status;
            this.code = code;
        }

        public ResponseContent(string userMessage, int status, string code, string requestId, string developerMessage, string moreInfo)
        {
            this.version = ResponseContent.ApiVersion;
            this.userMessage = userMessage;
            this.status = status;
            this.code = code;
            this.requestId = requestId;
            this.developerMessage = developerMessage;
            this.moreInfo = moreInfo;
        }

        //public ResponseContent(int result)
        //{
        //    this.result = result;            
        //}

        //public ResponseContent(DateTime dt)
        //{
        //    this.dt = dt;
        //}

        public ResponseContent(string userMessage, string status, string count)
        {
            this.version = ResponseContent.ApiVersion;
            this.userMessage = userMessage;
            //this.status = status;
            this.developerMessage = "This password has been seen " + count + " times before";
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string version { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string userMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string developerMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string requestId { get; set; }       
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string moreInfo { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public int result { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime dt { get; set; }
    }
}
