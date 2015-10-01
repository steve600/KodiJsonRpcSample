# KodiJsonRpcSample

In this simple console application it is shown how to create a valid JSON request and then how to send this request via HTTP to Kodi. This request has the following structure:

![Kodi-JsonRpc-Request](http://csharp-blog.de/wp-content/uploads/2015/09/Kodi_JsonRpc_GetMovies_Request.png)

And the result should look like this:

![Kodi-JsonRpc-Result](http://csharp-blog.de/wp-content/uploads/2015/09/Kodi_JsonRpc_GetMovies_Response.png)

For the JSON serialization the <a href="http://www.newtonsoft.com/json" target="_blank">Json.NET</a> framework is used. With the help of this framework it's very easy to create a JSON-RPC reqeust. Simply create a class, use the JsonProperty-Attribute and you're done! Here's the class for a JSON-RPC request:

```c#
/// <summary>
/// Represents a Json Rpc Request
/// </summary>
public class JsonRpcRequest
{
    public JsonRpcRequest()
    {
    }

    /// <summary>
    /// JSON-RPC Version
    /// </summary>
    [JsonProperty("jsonrpc", Required = Required.Always)]
    public string JsonRPC { get { return "2.0"; } }

    /// <summary>
    /// The id of the call
    /// </summary>
    [JsonProperty("id", Required = Required.Always)]
    public int Id { get; set; }

    /// <summary>
    /// The rpc method.
    /// </summary>
    [JsonProperty("method", Required = Required.Always)]
    public string Method { get; set; }

    /// <summary>
    /// Any parameters, optional.
    /// </summary>
    [JsonProperty("params")]
    public object Params { get; set; }

    /// <summary>
    /// ToString-Method
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
```

Such a request can now be easily created as shown here:

```c#
// Create request
var kodiRequest = new JsonRpcRequest()
{
    Method = "VideoLibrary.GetMovies",
    Params = new
    {
        properties = new string[] { "title", "genre", "year", "rating", "director", "plot", "plotoutline" },
        limits = new { start = 1, end = 100 },
        sort = new { order = "ascending", ignorearticle = true, method = "title" }
    }
};
''' 

The example does not cover the following points:

* Async communication
* Generic response
* TCP socket-based interface for communicating
* Websockets
* JSON specific details
* ...

It only shows the simplest form of communication. To successfully run the sample a running Kodi instance is required. To access Kodi's JSON-RPC API by sending JSON-RPC requests embedded in HTTP POST use the following URL:

http://{your-ip}:{your-port}/jsonrpc

Starting with Frodo nightly builds it is mandatory to set the HTTP header field Content-Type: application/json

More information: <a href="http://kodi.wiki/view/JSON-RPC_API#HTTP" target="_blank">http://kodi.wiki/view/JSON-RPC_API</a>
