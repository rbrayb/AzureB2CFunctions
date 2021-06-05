using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContentDate
    {
        public ResponseContentDate(DateTime dt)
        {
            this.date = dt;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime date{ get; set; }
    }
}
