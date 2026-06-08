using System;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class HeartbeatMessage : ServerMessage
{
	public HeartbeatMessage()
	{
		this.string_0 = DeProtectType.ArgValue_337;
	}
}
