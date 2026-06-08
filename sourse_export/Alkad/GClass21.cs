using System;
using System.Security.Cryptography;
using System.Text;
using GameWer;

// Token: 0x02000033 RID: 51
public class GClass21
{
	// Token: 0x060000D2 RID: 210 RVA: 0x00005A48 File Offset: 0x00003C48
	public static string smethod_0(string string_0)
	{
		string result;
		using (MD5 md = MD5.Create())
		{
			byte[] bytes = Encoding.ASCII.GetBytes(string_0);
			byte[] array = md.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString(DeProtectType.ArgValue_372));
			}
			result = stringBuilder.ToString().ToLower();
		}
		return result;
	}
}
