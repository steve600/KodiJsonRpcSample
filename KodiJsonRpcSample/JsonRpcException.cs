using Newtonsoft.Json;
using System;

namespace KodiJsonRpcSample
{
    /// <summary>
    /// Represents a Json Rpc Exception
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcException : System.ApplicationException
    {
        [JsonProperty]
        public int code { get; set; }

        [JsonProperty]
        public string message { get; set; }

        [JsonProperty]
        public object data { get; set; }

        public JsonRpcException(int code, string message, object data)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }
    }
}