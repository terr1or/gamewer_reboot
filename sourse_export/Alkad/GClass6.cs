using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameWer;
using Newtonsoft.Json;
using WebSocketSharp;

// Token: 0x0200001B RID: 27
public class GClass6
{
	// Token: 0x06000056 RID: 86 RVA: 0x00003D94 File Offset: 0x00001F94
	internal static void smethod_0()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_200, DeProtectType.ArgValue_201);
		GClass6.webSocket_0 = new WebSocket(((GClass26.string_1 == DeProtectType.ArgValue_202) ? DeProtectType.ArgValue_204 : DeProtectType.ArgValue_203) + DeProtectType.ArgValue_205 + GClass26.string_1 + DeProtectType.ArgValue_206, Array.Empty<string>());
		GClass6.webSocket_0.OnClose += GClass6.smethod_6;
		GClass6.webSocket_0.OnMessage += GClass6.smethod_5;
		GClass6.webSocket_0.OnOpen += GClass6.smethod_4;
		GClass6.webSocket_0.OnError += GClass6.smethod_2;
		GClass25.smethod_1(new Action(GClass6.Class7.class7_0.method_0), new Action<Exception>(GClass6.Class7.class7_0.method_2), 10f);
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003E94 File Offset: 0x00002094
	internal static void smethod_1(string string_0)
	{
		string str = GClass22.smethod_0(string_0, "");
		string str2 = GClass21.smethod_0(str + DeProtectType.ArgValue_207);
		WebSocket webSocket = GClass6.webSocket_0;
		if (webSocket != null)
		{
			webSocket.SendAsync(str + str2, new Action<bool>(GClass6.Class7.class7_0.method_3));
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002247 File Offset: 0x00000447
	private static void smethod_2(object sender, ErrorEventArgs e)
	{
		string argValue_ = DeProtectType.ArgValue_208;
		string argValue_2 = DeProtectType.ArgValue_209;
		string message = e.Message;
		string str = "\n";
		Exception exception = e.Exception;
		GClass7.smethod_0(argValue_, argValue_2 + message + str + ((exception != null) ? exception.ToString() : null));
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0000227A File Offset: 0x0000047A
	internal static void smethod_3()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_210, DeProtectType.ArgValue_211);
		GClass6.webSocket_0.ConnectAsync();
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003EF4 File Offset: 0x000020F4
	private static void smethod_4(object sender, EventArgs e)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_212, DeProtectType.ArgValue_213);
			GClass6.bool_0 = (int.Parse(DeProtectType.ArgValue_214) == 1);
			GClass4.smethod_12(new Action(GClass3.smethod_8));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_215;
			string argValue_2 = DeProtectType.ArgValue_216;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = GClass6.webSocket_0;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00003F80 File Offset: 0x00002180
	private static void smethod_5(object sender, MessageEventArgs e)
	{
		try
		{
			GClass6.Class8 @class = new GClass6.Class8();
			@class.string_0 = e.Data;
			@class.dictionary_0 = JsonConvert.DeserializeObject<Dictionary<string, object>>(@class.string_0);
			GClass4.smethod_12(new Action(@class.method_0));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_217;
			string argValue_2 = DeProtectType.ArgValue_218;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = GClass6.webSocket_0;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00004010 File Offset: 0x00002210
	private static void smethod_6(object sender, CloseEventArgs e)
	{
		try
		{
			GClass6.Class9 @class = new GClass6.Class9();
			@class.string_0 = e.Reason;
			GClass7.smethod_0(DeProtectType.ArgValue_219, string.Concat(new string[]
			{
				DeProtectType.ArgValue_220,
				((CloseStatusCode)e.Code).ToString(),
				DeProtectType.ArgValue_221,
				@class.string_0,
				DeProtectType.ArgValue_222
			}));
			GClass6.bool_0 = (int.Parse(DeProtectType.ArgValue_223) == 1);
			GClass4.smethod_12(new Action(@class.method_0));
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_224;
			string argValue_2 = DeProtectType.ArgValue_225;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			WebSocket webSocket = GClass6.webSocket_0;
			if (webSocket != null)
			{
				webSocket.CloseAsync(CloseStatusCode.InvalidData);
			}
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x000040EC File Offset: 0x000022EC
	internal static void smethod_7()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_226, DeProtectType.ArgValue_227);
		try
		{
			GClass6.webSocket_0.Close();
		}
		catch
		{
		}
	}

	// Token: 0x04000265 RID: 613
	internal static WebSocket webSocket_0;

	// Token: 0x04000266 RID: 614
	internal static bool bool_0 = false;

	// Token: 0x04000267 RID: 615
	internal static bool bool_1 = false;

	// Token: 0x0200001C RID: 28
	[CompilerGenerated]
	[Serializable]
	private sealed class Class7
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00004128 File Offset: 0x00002328
		internal void method_0()
		{
			if (GClass6.bool_0)
			{
				GClass6.webSocket_0.SendAsync(DeProtectType.ArgValue_228, new Action<bool>(GClass6.Class7.class7_0.method_1));
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_1(bool bool_0)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_2(Exception exception_0)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_3(bool bool_0)
		{
		}

		// Token: 0x04000268 RID: 616
		public static readonly GClass6.Class7 class7_0 = new GClass6.Class7();

		// Token: 0x04000269 RID: 617
		public static Action<bool> action_0;

		// Token: 0x0400026A RID: 618
		public static Action action_1;

		// Token: 0x0400026B RID: 619
		public static Action<Exception> action_2;

		// Token: 0x0400026C RID: 620
		public static Action<bool> action_3;
	}

	// Token: 0x0200001D RID: 29
	[CompilerGenerated]
	private sealed class Class8
	{
		// Token: 0x06000067 RID: 103 RVA: 0x0000416C File Offset: 0x0000236C
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
				GClass3.smethod_3(text, this.string_0, this.dictionary_0);
			}
		}

		// Token: 0x0400026D RID: 621
		public Dictionary<string, object> dictionary_0;

		// Token: 0x0400026E RID: 622
		public string string_0;
	}

	// Token: 0x0200001E RID: 30
	[CompilerGenerated]
	private sealed class Class9
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000022AF File Offset: 0x000004AF
		internal void method_0()
		{
			GClass3.smethod_7(this.string_0);
		}

		// Token: 0x0400026F RID: 623
		public string string_0;
	}
}
