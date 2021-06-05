using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContentBool
    {
        public ResponseContentBool(bool compResult)
        {
            this.compResult = compResult;            
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool compResult { get; set; }
    }
}
