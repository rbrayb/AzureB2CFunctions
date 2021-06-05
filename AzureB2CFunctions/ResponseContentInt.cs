using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContentInt
    {
        public ResponseContentInt(int result)
        {
            this.result = result;            
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int result { get; set; }
    }
}
