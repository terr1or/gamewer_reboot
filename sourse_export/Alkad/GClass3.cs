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

// Token: 0x02000014 RID: 20
public class GClass3
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000024 RID: 36 RVA: 0x0000209C File Offset: 0x0000029C
	// (set) Token: 0x06000025 RID: 37 RVA: 0x000020A3 File Offset: 0x000002A3
	private static GClass12 GClass12_0 { get; set; } = null;

	// Token: 0x06000026 RID: 38 RVA: 0x00002C6C File Offset: 0x00000E6C
	internal static void smethod_0(GClass14 gclass14_0)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_33, DeProtectType.ArgValue_34 + gclass14_0.bool_0.ToString());
			GClass3.string_0 = gclass14_0.string_2;
			GClass3.string_2 = gclass14_0.string_1;
			GClass10.igameWerForm_0.OnNetworkAuthSuccess();
			if (GClass3.GClass12_0 != null)
			{
				GClass3.smethod_6(GClass3.GClass12_0);
			}
			string text = new GClass16
			{
				string_1 = string.Join(DeProtectType.ArgValue_35, GClass33.List_0),
				string_2 = GClass33.string_2,
				string_14 = GClass33.string_15,
				int_1 = int.Parse(GClass33.string_16),
				string_8 = GClass33.string_8,
				string_3 = GClass33.string_3,
				int_0 = int.Parse(GClass33.string_10),
				string_5 = GClass33.string_5,
				string_6 = GClass33.string_6,
				string_11 = GClass33.string_12,
				string_10 = GClass33.string_11,
				string_4 = GClass33.string_4,
				string_7 = GClass33.string_7,
				string_9 = GClass33.string_9,
				string_13 = GClass33.string_14,
				string_12 = GClass33.string_13,
				bool_0 = GClass33.bool_0,
				string_15 = GClass21.smethod_0(GClass3.string_1 + GClass3.string_2 + DeProtectType.ArgValue_36)
			}.vmethod_0();
			GClass6.smethod_1(text);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_37;
			string argValue_2 = DeProtectType.ArgValue_38;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002E10 File Offset: 0x00001010
	internal static void smethod_1(GClass15 gclass15_0)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_39, DeProtectType.ArgValue_40);
			GClass10.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_41);
			GClass6.bool_1 = true;
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_42;
			string argValue_2 = DeProtectType.ArgValue_43;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002E78 File Offset: 0x00001078
	private static void smethod_2(GClass18 gclass18_0)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_44, DeProtectType.ArgValue_45);
			GClass8.hashSet_0 = new HashSet<string>();
			GClass8.smethod_8();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_46;
			string argValue_2 = DeProtectType.ArgValue_47;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002EDC File Offset: 0x000010DC
	internal static void smethod_3(string string_3, string string_4, Dictionary<string, object> dictionary_0)
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
										GClass19 gclass19_ = GClass19.smethod_1(dictionary_0);
										GClass3.smethod_4(gclass19_);
									}
								}
								else
								{
									GClass12 gclass12_ = GClass12.smethod_1(dictionary_0);
									GClass3.smethod_6(gclass12_);
								}
							}
							else
							{
								GClass18 gclass18_ = new GClass18();
								GClass3.smethod_2(gclass18_);
							}
						}
						else
						{
							GClass15 gclass15_ = new GClass15();
							GClass3.smethod_1(gclass15_);
						}
					}
					else
					{
						GClass3.smethod_5(dictionary_0[DeProtectType.ArgValue_54] as string);
					}
				}
				else
				{
					GClass14 gclass = GClass14.smethod_1(dictionary_0);
					if (gclass.bool_0)
					{
						GClass3.smethod_0(gclass);
					}
					else
					{
						GClass6.webSocket_0.CloseAsync(CloseStatusCode.UnsupportedData);
					}
				}
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_55;
			string argValue_2 = DeProtectType.ArgValue_56;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00003000 File Offset: 0x00001200
	internal static void smethod_4(GClass19 gclass19_0)
	{
		GClass3.Class4 @class = new GClass3.Class4();
		@class.gclass19_0 = gclass19_0;
		Console.WriteLine(DeProtectType.ArgValue_57);
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000020AB File Offset: 0x000002AB
	private static void smethod_5(string string_3)
	{
		SystemSounds.Asterisk.Play();
		ThreadPool.QueueUserWorkItem(new WaitCallback(GClass3.Class5.class5_0.method_0));
		GClass10.igameWerForm_0.OnIncomingCode(string_3);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003038 File Offset: 0x00001238
	private static void smethod_6(GClass12 gclass12_1)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_58, DeProtectType.ArgValue_59 + gclass12_1.string_1 + DeProtectType.ArgValue_60 + GClass23.smethod_0(gclass12_1.uint_0).ToString());
			DateTime finish_at = GClass23.smethod_0(gclass12_1.uint_0);
			GClass3.GClass12_0 = gclass12_1;
			GClass10.igameWerForm_0.OnIncomingBanned(gclass12_1.string_1, finish_at);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_61;
			string argValue_2 = DeProtectType.ArgValue_62;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000030D8 File Offset: 0x000012D8
	internal static void smethod_7(string string_3)
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_63, DeProtectType.ArgValue_64 + string_3 + DeProtectType.ArgValue_65);
			GClass8.hashSet_0 = null;
			GClass3.GClass12_0 = null;
			GClass10.igameWerForm_0.OnNetworkDisconnected(string_3);
			if (GClass4.bool_0)
			{
				GClass25.smethod_0(new Action(GClass3.Class5.class5_0.method_1), new Action<Exception>(GClass3.Class5.class5_0.method_2), 3f);
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_66;
			string argValue_2 = DeProtectType.ArgValue_67;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000031A0 File Offset: 0x000013A0
	internal static void smethod_8()
	{
		if (GAttribute0.string_0 == string.Empty)
		{
			GClass10.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_68);
			SystemSounds.Asterisk.Play();
			MessageBox.Show("[RU] Для работы GameWer, необходимо что бы - был запущен Discord. Хотя бы до окочания авторизации(Пока вы не увидите статус онлайн). А потом вы можете его смело закрыть, если он вам мешает. Ваш дискорд аккаунт должен быть связан с номером телефона! А вы, для авторизации - должны быть на нашем дискорд сервере! Кнопка присоеденится, в самом низу окошка античита.\n\n[EN] For GameWer to work, you need to have Discord running. At least until the end of the authorization (Until you see the online status). And then you can safely close it if it bothers you. Your discord account must be linked to a phone number! And you, for authorization, must be on our discord server! The button will connect, at the very bottom of the anti-cheat window.");
			GClass7.smethod_0(DeProtectType.ArgValue_69, DeProtectType.ArgValue_70);
			GClass4.smethod_11();
		}
		else
		{
			try
			{
				GClass7.smethod_0(DeProtectType.ArgValue_71, DeProtectType.ArgValue_72);
				GClass10.igameWerForm_0.OnNetworkConnected();
				GClass3.string_1 = GClass21.smethod_0(DateTime.Now.ToString());
				GClass13 gclass = new GClass13
				{
					string_1 = DeProtectType.ArgValue_73,
					string_2 = GClass28.smethod_1().ToString().Substring(0, 17),
					string_3 = "",
					string_4 = GClass33.string_1,
					string_5 = GAttribute0.string_0,
					string_6 = GClass3.string_0,
					string_7 = GClass3.string_1,
					string_8 = GClass21.smethod_0(GClass3.string_1 + DeProtectType.ArgValue_74)
				};
				GClass6.smethod_1(gclass.vmethod_0());
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_75;
				string argValue_2 = DeProtectType.ArgValue_76;
				Exception ex2 = ex;
				GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
	}

	// Token: 0x04000255 RID: 597
	internal static string string_0 = string.Empty;

	// Token: 0x04000256 RID: 598
	internal static string string_1 = string.Empty;

	// Token: 0x04000257 RID: 599
	internal static string string_2 = string.Empty;

	// Token: 0x04000258 RID: 600
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static GClass12 gclass12_0;

	// Token: 0x02000015 RID: 21
	[CompilerGenerated]
	private sealed class Class4
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000032EC File Offset: 0x000014EC
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

		// Token: 0x06000033 RID: 51 RVA: 0x0000332C File Offset: 0x0000152C
		internal void method_1()
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					GClass9.smethod_2(memoryStream);
					byte[] buffer = memoryStream.GetBuffer();
					if (buffer.Length > 1024)
					{
						using (WebClient webClient = new WebClient())
						{
							try
							{
								webClient.Encoding = Encoding.UTF8;
								GClass9.smethod_0(webClient, buffer, this.gclass19_0.string_1);
							}
							catch (Exception)
							{
								GClass7.smethod_0(DeProtectType.ArgValue_77, DeProtectType.ArgValue_78);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				GClass7.smethod_0(DeProtectType.ArgValue_79, DeProtectType.ArgValue_80);
			}
		}

		// Token: 0x04000259 RID: 601
		public GClass19 gclass19_0;

		// Token: 0x0400025A RID: 602
		public ThreadStart threadStart_0;
	}

	// Token: 0x02000016 RID: 22
	[CompilerGenerated]
	[Serializable]
	private sealed class Class5
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00002119 File Offset: 0x00000319
		internal void method_0(object object_0)
		{
			MessageBox.Show("[RU] Теперь для идентификации пользователя используется Discord для ПК.\n Впишите 4-х значный код из строки Status в канал #authentication и вы будете авторизованы!\n \n [EN] Discord for Desktop is now used to authenticate the user.\n Enter the 4-digit code from the Status line into the #authentication channel and you will be logged in!\n \n [ES] Discord para PC ahora se usa para autenticar al usuario.\n Ingrese el código de 4 dígitos de la línea de estado en el canal #authentication y ¡iniciará sesión!");
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000033F8 File Offset: 0x000015F8
		internal void method_1()
		{
			if (GClass6.bool_1 == (int.Parse(DeProtectType.ArgValue_81) == 1))
			{
				GClass6.webSocket_0.ConnectAsync();
			}
			else
			{
				GClass7.smethod_0(DeProtectType.ArgValue_82, DeProtectType.ArgValue_83);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002126 File Offset: 0x00000326
		internal void method_2(Exception exception_0)
		{
			GClass7.smethod_0(DeProtectType.ArgValue_84, DeProtectType.ArgValue_85 + ((exception_0 != null) ? exception_0.ToString() : null));
		}

		// Token: 0x0400025B RID: 603
		public static readonly GClass3.Class5 class5_0 = new GClass3.Class5();

		// Token: 0x0400025C RID: 604
		public static WaitCallback waitCallback_0;

		// Token: 0x0400025D RID: 605
		public static Action action_0;

		// Token: 0x0400025E RID: 606
		public static Action<Exception> action_1;
	}
}
