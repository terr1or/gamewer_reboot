using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using GameWer;

// Token: 0x02000034 RID: 52
public class GClass22
{
	// Token: 0x060000D4 RID: 212 RVA: 0x00005AD0 File Offset: 0x00003CD0
	public static string smethod_0(string string_0, string string_1)
	{
		byte[] array = new byte[8];
		RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
		rngcryptoServiceProvider.GetNonZeroBytes(array);
		byte[] byte_;
		byte[] byte_2;
		GClass22.smethod_2(string_1, array, out byte_, out byte_2);
		byte[] array2 = GClass22.smethod_3(string_0, byte_, byte_2);
		byte[] array3 = new byte[array.Length + array2.Length + 8];
		Buffer.BlockCopy(Encoding.ASCII.GetBytes(DeProtectType.ArgValue_373), 0, array3, 0, 8);
		Buffer.BlockCopy(array, 0, array3, 8, array.Length);
		Buffer.BlockCopy(array2, 0, array3, array.Length + 8, array2.Length);
		return Convert.ToBase64String(array3);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00005B5C File Offset: 0x00003D5C
	public static string smethod_1(string string_0, string string_1)
	{
		byte[] array = Convert.FromBase64String(string_0);
		byte[] array2 = new byte[8];
		byte[] array3 = new byte[array.Length - array2.Length - 8];
		Buffer.BlockCopy(array, 8, array2, 0, array2.Length);
		Buffer.BlockCopy(array, array2.Length + 8, array3, 0, array3.Length);
		byte[] byte_;
		byte[] byte_2;
		GClass22.smethod_2(string_1, array2, out byte_, out byte_2);
		return GClass22.smethod_4(array3, byte_, byte_2);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00005BBC File Offset: 0x00003DBC
	private static void smethod_2(string string_0, byte[] byte_0, out byte[] byte_1, out byte[] byte_2)
	{
		List<byte> list = new List<byte>(48);
		byte[] array = Encoding.UTF8.smethod_0(string_0);
		byte[] array2 = new byte[0];
		MD5 md = MD5.Create();
		bool flag = false;
		while (!flag)
		{
			int num = array2.Length + array.Length + byte_0.Length;
			byte[] array3 = new byte[num];
			Buffer.BlockCopy(array2, 0, array3, 0, array2.Length);
			Buffer.BlockCopy(array, 0, array3, array2.Length, array.Length);
			Buffer.BlockCopy(byte_0, 0, array3, array2.Length + array.Length, byte_0.Length);
			array2 = md.ComputeHash(array3);
			list.AddRange(array2);
			if (list.Count >= 48)
			{
				flag = true;
			}
		}
		byte_1 = new byte[32];
		byte_2 = new byte[16];
		list.CopyTo(0, byte_1, 0, 32);
		list.CopyTo(32, byte_2, 0, 16);
		md.Clear();
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00005C90 File Offset: 0x00003E90
	private static byte[] smethod_3(string string_0, byte[] byte_0, byte[] byte_1)
	{
		if (string_0 == null || string_0.Length <= 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_374);
		}
		if (byte_0 == null || byte_0.Length == 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_375);
		}
		if (byte_1 == null || byte_1.Length == 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_376);
		}
		RijndaelManaged rijndaelManaged = null;
		MemoryStream memoryStream;
		try
		{
			rijndaelManaged = new RijndaelManaged
			{
				KeySize = 256,
				BlockSize = 128,
				Key = byte_0,
				IV = byte_1
			};
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
				{
					streamWriter.Write(string_0);
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
		}
		finally
		{
			if (rijndaelManaged != null)
			{
				rijndaelManaged.Clear();
			}
		}
		return memoryStream.ToArray();
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00005DBC File Offset: 0x00003FBC
	private static string smethod_4(byte[] byte_0, byte[] byte_1, byte[] byte_2)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_377);
		}
		if (byte_1 == null || byte_1.Length == 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_378);
		}
		if (byte_2 == null || byte_2.Length == 0)
		{
			throw new ArgumentNullException(DeProtectType.ArgValue_379);
		}
		RijndaelManaged rijndaelManaged = null;
		string result;
		try
		{
			rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				KeySize = 256,
				BlockSize = 128,
				Key = byte_1,
				IV = byte_2
			};
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using (MemoryStream memoryStream = new MemoryStream(byte_0))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
				{
					using (StreamReader streamReader = new StreamReader(cryptoStream))
					{
						result = streamReader.ReadToEnd();
						streamReader.Close();
					}
				}
			}
		}
		finally
		{
			if (rijndaelManaged != null)
			{
				rijndaelManaged.Clear();
			}
		}
		return result;
	}
}
