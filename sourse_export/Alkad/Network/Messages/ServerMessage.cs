using System;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ServerMessage
{
	internal virtual string vmethod_0()
	{
		return JsonConvert.SerializeObject(this);
	}
	[JsonProperty("method")]
	internal string string_0;
}
