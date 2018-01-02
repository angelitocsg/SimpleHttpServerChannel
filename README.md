# SimpleHttpServerChannel
Example of using the HttpServerChannel and HttpClientChannel classes in .NET

## Projects in solution
### AppServer

Create a Http Server Channel for remote requests.

```csharp
HttpServerChannel httpServerChannel = new HttpServerChannel(9090);
ChannelServices.RegisterChannel(httpServerChannel);
RemotingConfiguration.RegisterWellKnownServiceType(typeof(XmlData.ServiceCollection), 
    "Services", WellKnownObjectMode.SingleCall);
```

### AppClient

Create a Http Client Channel connecting to the server.

```csharp
HttpClientChannel httpClientChannel = new HttpClientChannel();
ChannelServices.RegisterChannel(httpClientChannel, false);
String serviceUrl = string.Format("http://{0}:{1}/{2}", "127.0.0.1", 9090, "Services");
WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(XmlData.ServiceCollection), serviceUrl);
RemotingConfiguration.RegisterWellKnownClientType(remoteType);
```

### XmlData

Class referenced on server must implement `MarshalByRefObject` and return in simple formats, like: `String`, `int`, `array`.
For complex data, an alternative is serialize class to Xml on server and deserialize Xml to class on client.

```csharp
public class ServiceCollection : MarshalByRefObject {
    public Service[] Services;
```

Data class must be `Serializable`.
```csharp
[Serializable]
public class Service
```
