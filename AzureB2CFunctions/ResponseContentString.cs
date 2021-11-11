using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContentString
    {
        public ResponseContentString(string compResult)
        {
            this.compResult = compResult;            
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string compResult { get; set; }
    }
}
