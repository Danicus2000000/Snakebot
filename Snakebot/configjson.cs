using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Server_Servant
{
    public struct configjson
    {
        [JsonProperty("token")]//gets token from json file sets it to store in token
        public string token { get; private set; }
    }
}
