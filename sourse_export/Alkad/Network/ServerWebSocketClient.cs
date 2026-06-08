using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameWer;
using Newtonsoft.Json;
using WebSocketSharp;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ServerWebSocketClient
{
	internal static void Initialize()
	{
		FileLogger.Log(DeProtectType.ArgValue_200, DeProtectType.ArgValue_201);
		ServerWebSocketClient.webSocket = new WebSocket(((ClientRuntimeState.string_1 == DeProtectType.ArgValue_202) ? DeProtectType.ArgValue_204 : DeProtectType.ArgValue_203) + DeProtectType.ArgValue_205 + ClientRuntimeState.string_1 + DeProtectType.ArgValue_206, Array.Empty<string>());
		ServerWebSocketClient.webSocket.OnClose += ServerWebSocketClient.HandleClose;
		ServerWebSocketClient.webSocket.OnMessage += ServerWebSocketClient.HandleMessage;
		ServerWebSocketClient.webSocket.OnOpen += ServerWebSocketClient.HandleOpen;
		ServerWebSocketClient.webSocket.OnError += ServerWebSocketClient.HandleError;
		RetryScheduler.RunForeverDelayed(new Action(ServerWebSocketClient.Class7.class7_0.method_0), new Action<Exception>(ServerWebSocketClient.Class7.class7_0.method_2), 10f);
	}
	internal static void SendEncrypted(string string_0)
	{
		string str = CryptoEnvelope.Encrypt(string_0, "");
		string str2 = HashUtility.ComputeMd5(str + DeProtectType.ArgValue_207);
		WebSocket webSocket = ServerWebSocketClient.webSocket;
		if (webSocket != null)
		{
			webSocket.SendAsync(str + str2, new Action<bool>(ServerWebSocketClient.Class7.class7_0.method_3));
		}
	}
	private static void HandleError(object sender, ErrorEventArgs e)
	{
		string argValue_ = DeProtectType.ArgValue_208;
		string argValue_2 = DeProtectType.ArgValue_209;
		string message = e.Message;
		string str = "\n";
		Exception exception = e.Exception;
		FileLogger.Log(argValue_, argValue_2 + message + str + ((exception != null) ? exception.ToString() : null));
	}
	internal static void Connect()
	{
		FileLogger.Log(DeProtectType.ArgValue_210, DeProtectType.ArgValue_211);
		ServerWebSocketClient.webSocket.ConnectAsync();
	}
	private static void HandleOpen(object sender, EventArgs e)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_212, DeProtectType.ArgValue_213);
			ServerWebSocketClient.isConnected = (int.Parse(DeProtectType.ArgValue_214) == 1);
			RuntimeGuard.EnqueueOnMainLoop(new Action(SteamSessionManager.SendAuthentication));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_215;
			string argValue_2 = DeProtectType.ArgValue_216;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = ServerWebSocketClient.webSocket;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}
	private static void HandleMessage(object sender, MessageEventArgs e)
	{
		try
		{
			ServerWebSocketClient.Class8 @class = new ServerWebSocketClient.Class8();
			@class.string_0 = e.Data;
			@class.dictionary_0 = JsonConvert.DeserializeObject<Dictionary<string, object>>(@class.string_0);
			RuntimeGuard.EnqueueOnMainLoop(new Action(@class.method_0));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_217;
			string argValue_2 = DeProtectType.ArgValue_218;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = ServerWebSocketClient.webSocket;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}
	private static void HandleClose(object sender, CloseEventArgs e)
	{
		try
		{
			ServerWebSocketClient.Class9 @class = new ServerWebSocketClient.Class9();
			@class.string_0 = e.Reason;
			FileLogger.Log(DeProtectType.ArgValue_219, string.Concat(new string[]
			{
				DeProtectType.ArgValue_220,
				((CloseStatusCode)e.Code).ToString(),
				DeProtectType.ArgValue_221,
				@class.string_0,
				DeProtectType.ArgValue_222
			}));
			ServerWebSocketClient.isConnected = (int.Parse(DeProtectType.ArgValue_223) == 1);
			RuntimeGuard.EnqueueOnMainLoop(new Action(@class.method_0));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_224;
			string argValue_2 = DeProtectType.ArgValue_225;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = ServerWebSocketClient.webSocket;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}
	internal static void Close()
	{
		FileLogger.Log(DeProtectType.ArgValue_226, DeProtectType.ArgValue_227);
		try
		{
			ServerWebSocketClient.webSocket.Close();
		}
		catch
		{
		}
	}
	internal static WebSocket webSocket;
	internal static bool isConnected = false;
	internal static bool isAuthenticated = false;
	[CompilerGenerated]
	[Serializable]
	private sealed class Class7
	{
		internal void method_0()
		{
			if (ServerWebSocketClient.isConnected)
			{
				ServerWebSocketClient.webSocket.SendAsync(DeProtectType.ArgValue_228, new Action<bool>(ServerWebSocketClient.Class7.class7_0.method_1));
			}
		}
		internal void method_1(bool isConnected)
		{
		}
		internal void method_2(Exception exception_0)
		{
		}
		internal void method_3(bool isConnected)
		{
		}
		public static readonly ServerWebSocketClient.Class7 class7_0 = new ServerWebSocketClient.Class7();
		public static Action<bool> action_0;
		public static Action action_1;
		public static Action<Exception> action_2;
		public static Action<bool> action_3;
	}
	[CompilerGenerated]
	private sealed class Class8
	{
		internal void method_0()
		{
			object obj;
			string text;
			bool flag;
			if (this.dictionary_0.TryGetValue(DeProtectType.ArgValue_229, out obj))
			{
				text = (obj as string);
				flag = (text != null);
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				SteamSessionManager.HandleServerMethod(text, this.string_0, this.dictionary_0);
			}
		}
		public Dictionary<string, object> dictionary_0;
		public string string_0;
	}
	[CompilerGenerated]
	private sealed class Class9
	{
		internal void method_0()
		{
			SteamSessionManager.HandleDisconnect(this.string_0);
		}
		public string string_0;
	}
}
