using System;
using System.Net;
using Newtonsoft.Json;

namespace AzureB2CFunctions
{
    public class ResponseContentJWT
    {
        public ResponseContentJWT()
        {
            this.displayName = "Joe Bloggs";
            this.givenName = "Joe";
            this.surName = "Bloggs";
            this.role = "Admin";
            this.objectId = "83a7d054-7129-4d11-9403-53bbccbb7f19";
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string displayName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string givenName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string surName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string role { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }

    }
}
