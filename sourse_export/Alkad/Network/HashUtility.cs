using System;
using System.Security.Cryptography;
using System.Text;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class HashUtility
{
	public static string ComputeMd5(string value)
	{
		string result;
		using (MD5 md = MD5.Create())
		{
			byte[] bytes = Encoding.ASCII.GetBytes(value);
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
