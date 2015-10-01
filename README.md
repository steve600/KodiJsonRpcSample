# KodiJsonRpcSample

In this simple console application it is shown how to create a valid JSON request and then how to send this request via HTTP to Kodi. This request has the following structure:

![Kodi-JsonRpc-Request](http://csharp-blog.de/wp-content/uploads/2015/09/Kodi_JsonRpc_GetMovies_Request.png)

And the result should look like this:

![Kodi-JsonRpc-Result](http://csharp-blog.de/wp-content/uploads/2015/09/Kodi_JsonRpc_GetMovies_Response.png)

For the JSON serialization the great <a href="http://www.newtonsoft.com/json" target="_blank">Json.NET</a> framework is used. The example does not cover the following points:

* Async communication
* Generic response
* TCP socket-based interface for communicating
* Websockets
* JSON specific details
* ...

It only shows the simplest form of communication. To successfully run the sample you need a running Kodi instance is required. To access Kodi's JSON-RPC API by sending JSON-RPC requests embedded in HTTP POST requests use the following URL:

http://<your-ip>:<your-port>/jsonrpc

Starting with Frodo nightly builds it is mandatory to set the HTTP header field Content-Type: application/json

More information: <a href="http://kodi.wiki/view/JSON-RPC_API#HTTP" target="_blank">http://kodi.wiki/view/JSON-RPC_API#HTTP</a>
