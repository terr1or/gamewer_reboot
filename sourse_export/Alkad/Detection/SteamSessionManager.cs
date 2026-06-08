using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameWer;
using WebSocketSharp;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class SteamSessionManager
{
	// (get) Token: 0x06000024 RID: 36 RVA: 0x0000209C File Offset: 0x0000029C
	// (set) Token: 0x06000025 RID: 37 RVA: 0x000020A3 File Offset: 0x000002A3
	private static ServerBanMessage GClass12_0 { get; set; } = null;
	internal static void smethod_0(AuthenticationResponseMessage gclass14_0)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_33, DeProtectType.ArgValue_34 + gclass14_0.bool_0.ToString());
			SteamSessionManager.string_0 = gclass14_0.string_2;
			SteamSessionManager.string_2 = gclass14_0.string_1;
			IsolatedBootstrapper.igameWerForm_0.OnNetworkAuthSuccess();
			if (SteamSessionManager.GClass12_0 != null)
			{
				SteamSessionManager.smethod_6(SteamSessionManager.GClass12_0);
			}
			string text = new ProcessReportMessage
			{
				string_1 = string.Join(DeProtectType.ArgValue_35, SystemInventory.List_0),
				string_2 = SystemInventory.string_2,
				string_14 = SystemInventory.string_15,
				int_1 = int.Parse(SystemInventory.string_16),
				string_8 = SystemInventory.string_8,
				string_3 = SystemInventory.string_3,
				int_0 = int.Parse(SystemInventory.string_10),
				string_5 = SystemInventory.string_5,
				string_6 = SystemInventory.string_6,
				string_11 = SystemInventory.string_12,
				string_10 = SystemInventory.string_11,
				string_4 = SystemInventory.string_4,
				string_7 = SystemInventory.string_7,
				string_9 = SystemInventory.string_9,
				string_13 = SystemInventory.string_14,
				string_12 = SystemInventory.string_13,
				bool_0 = SystemInventory.bool_0,
				string_15 = HashUtility.ComputeMd5(SteamSessionManager.string_1 + SteamSessionManager.string_2 + DeProtectType.ArgValue_36)
			}.vmethod_0();
			ServerWebSocketClient.SendEncrypted(text);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_37;
			string argValue_2 = DeProtectType.ArgValue_38;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void smethod_1(HeartbeatMessage gclass15_0)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_39, DeProtectType.ArgValue_40);
			IsolatedBootstrapper.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_41);
			ServerWebSocketClient.bool_1 = true;
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_42;
			string argValue_2 = DeProtectType.ArgValue_43;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	private static void smethod_2(ScreenshotRequestMessage gclass18_0)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_44, DeProtectType.ArgValue_45);
			ModuleMonitor.hashSet_0 = new HashSet<string>();
			ModuleMonitor.ScanLoop();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_46;
			string argValue_2 = DeProtectType.ArgValue_47;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void HandleServerMethod(string string_3, string string_4, Dictionary<string, object> dictionary_0)
	{
		try
		{
			if (string_3 != null)
			{
				if (!(string_3 == DeProtectType.ArgValue_48))
				{
					if (!(string_3 == DeProtectType.ArgValue_49))
					{
						if (!(string_3 == DeProtectType.ArgValue_50))
						{
							if (!(string_3 == DeProtectType.ArgValue_51))
							{
								if (!(string_3 == DeProtectType.ArgValue_52))
								{
									if (string_3 == DeProtectType.ArgValue_53)
									{
										DisconnectMessage gclass19_ = DisconnectMessage.smethod_1(dictionary_0);
										SteamSessionManager.smethod_4(gclass19_);
									}
								}
								else
								{
									ServerBanMessage gclass12_ = ServerBanMessage.smethod_1(dictionary_0);
									SteamSessionManager.smethod_6(gclass12_);
								}
							}
							else
							{
								ScreenshotRequestMessage gclass18_ = new ScreenshotRequestMessage();
								SteamSessionManager.smethod_2(gclass18_);
							}
						}
						else
						{
							HeartbeatMessage gclass15_ = new HeartbeatMessage();
							SteamSessionManager.smethod_1(gclass15_);
						}
					}
					else
					{
						SteamSessionManager.smethod_5(dictionary_0[DeProtectType.ArgValue_54] as string);
					}
				}
				else
				{
					AuthenticationResponseMessage gclass = AuthenticationResponseMessage.smethod_1(dictionary_0);
					if (gclass.bool_0)
					{
						SteamSessionManager.smethod_0(gclass);
					}
					else
					{
						ServerWebSocketClient.webSocket_0.CloseAsync(CloseStatusCode.UnsupportedData);
					}
				}
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_55;
			string argValue_2 = DeProtectType.ArgValue_56;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void smethod_4(DisconnectMessage gclass19_0)
	{
		SteamSessionManager.Class4 @class = new SteamSessionManager.Class4();
		@class.gclass19_0 = gclass19_0;
		Console.WriteLine(DeProtectType.ArgValue_57);
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}
	private static void smethod_5(string string_3)
	{
		SystemSounds.Asterisk.Play();
		ThreadPool.QueueUserWorkItem(new WaitCallback(SteamSessionManager.Class5.class5_0.method_0));
		IsolatedBootstrapper.igameWerForm_0.OnIncomingCode(string_3);
	}
	private static void smethod_6(ServerBanMessage gclass12_1)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_58, DeProtectType.ArgValue_59 + gclass12_1.string_1 + DeProtectType.ArgValue_60 + UnixClock.smethod_0(gclass12_1.uint_0).ToString());
			DateTime finish_at = UnixClock.smethod_0(gclass12_1.uint_0);
			SteamSessionManager.GClass12_0 = gclass12_1;
			IsolatedBootstrapper.igameWerForm_0.OnIncomingBanned(gclass12_1.string_1, finish_at);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_61;
			string argValue_2 = DeProtectType.ArgValue_62;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void HandleDisconnect(string string_3)
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_63, DeProtectType.ArgValue_64 + string_3 + DeProtectType.ArgValue_65);
			ModuleMonitor.hashSet_0 = null;
			SteamSessionManager.GClass12_0 = null;
			IsolatedBootstrapper.igameWerForm_0.OnNetworkDisconnected(string_3);
			if (RuntimeGuard.bool_0)
			{
				RetryScheduler.RunForever(new Action(SteamSessionManager.Class5.class5_0.method_1), new Action<Exception>(SteamSessionManager.Class5.class5_0.method_2), 3f);
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_66;
			string argValue_2 = DeProtectType.ArgValue_67;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void SendAuthentication()
	{
		if (DiscordRichPresenceManager.string_0 == string.Empty)
		{
			IsolatedBootstrapper.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_68);
			SystemSounds.Asterisk.Play();
			MessageBox.Show("[RU] Для работы GameWer, необходимо что бы - был запущен Discord. Хотя бы до окочания авторизации(Пока вы не увидите статус онлайн). А потом вы можете его смело закрыть, если он вам мешает. Ваш дискорд аккаунт должен быть связан с номером телефона! А вы, для авторизации - должны быть на нашем дискорд сервере! Кнопка присоеденится, в самом низу окошка античита.\n\n[EN] For GameWer to work, you need to have Discord running. At least until the end of the authorization (Until you see the online status). And then you can safely close it if it bothers you. Your discord account must be linked to a phone number! And you, for authorization, must be on our discord server! The button will connect, at the very bottom of the anti-cheat window.");
			FileLogger.Log(DeProtectType.ArgValue_69, DeProtectType.ArgValue_70);
			RuntimeGuard.ExitApplication();
		}
		else
		{
			try
			{
				FileLogger.Log(DeProtectType.ArgValue_71, DeProtectType.ArgValue_72);
				IsolatedBootstrapper.igameWerForm_0.OnNetworkConnected();
				SteamSessionManager.string_1 = HashUtility.ComputeMd5(DateTime.Now.ToString());
				AuthenticationRequestMessage gclass = new AuthenticationRequestMessage
				{
					string_1 = DeProtectType.ArgValue_73,
					string_2 = TokenPrivilegeInspector.smethod_1().ToString().Substring(0, 17),
					string_3 = "",
					string_4 = SystemInventory.string_1,
					string_5 = DiscordRichPresenceManager.string_0,
					string_6 = SteamSessionManager.string_0,
					string_7 = SteamSessionManager.string_1,
					string_8 = HashUtility.ComputeMd5(SteamSessionManager.string_1 + DeProtectType.ArgValue_74)
				};
				ServerWebSocketClient.SendEncrypted(gclass.vmethod_0());
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_75;
				string argValue_2 = DeProtectType.ArgValue_76;
				Exception ex2 = ex;
				FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
	}
	internal static string string_0 = string.Empty;
	internal static string string_1 = string.Empty;
	internal static string string_2 = string.Empty;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static ServerBanMessage gclass12_0;
	[CompilerGenerated]
	private sealed class Class4
	{
		internal void method_0(object object_0)
		{
			ThreadStart start;
			if ((start = this.threadStart_0) == null)
			{
				start = (this.threadStart_0 = new ThreadStart(this.method_1));
			}
			Thread thread = new Thread(start);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
		internal void method_1()
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					ScreenshotService.smethod_2(memoryStream);
					byte[] buffer = memoryStream.GetBuffer();
					if (buffer.Length > 1024)
					{
						using (WebClient webClient = new WebClient())
						{
							try
							{
								webClient.Encoding = Encoding.UTF8;
								ScreenshotService.smethod_0(webClient, buffer, this.gclass19_0.string_1);
							}
							catch (Exception)
							{
								FileLogger.Log(DeProtectType.ArgValue_77, DeProtectType.ArgValue_78);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				FileLogger.Log(DeProtectType.ArgValue_79, DeProtectType.ArgValue_80);
			}
		}
		public DisconnectMessage gclass19_0;
		public ThreadStart threadStart_0;
	}
	[CompilerGenerated]
	[Serializable]
	private sealed class Class5
	{
		internal void method_0(object object_0)
		{
			MessageBox.Show("[RU] Теперь для идентификации пользователя используется Discord для ПК.\n Впишите 4-х значный код из строки Status в канал #authentication и вы будете авторизованы!\n \n [EN] Discord for Desktop is now used to authenticate the user.\n Enter the 4-digit code from the Status line into the #authentication channel and you will be logged in!\n \n [ES] Discord para PC ahora se usa para autenticar al usuario.\n Ingrese el código de 4 dígitos de la línea de estado en el canal #authentication y ¡iniciará sesión!");
		}
		internal void method_1()
		{
			if (ServerWebSocketClient.bool_1 == (int.Parse(DeProtectType.ArgValue_81) == 1))
			{
				ServerWebSocketClient.webSocket_0.ConnectAsync();
			}
			else
			{
				FileLogger.Log(DeProtectType.ArgValue_82, DeProtectType.ArgValue_83);
			}
		}
		internal void method_2(Exception exception_0)
		{
			FileLogger.Log(DeProtectType.ArgValue_84, DeProtectType.ArgValue_85 + ((exception_0 != null) ? exception_0.ToString() : null));
		}
		public static readonly SteamSessionManager.Class5 class5_0 = new SteamSessionManager.Class5();
		public static WaitCallback waitCallback_0;
		public static Action action_0;
		public static Action<Exception> action_1;
	}
}
