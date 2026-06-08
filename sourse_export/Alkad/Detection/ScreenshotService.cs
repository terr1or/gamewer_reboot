using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ScreenshotService
{
	internal static void smethod_0(WebClient webClient_0, byte[] byte_0, string string_0)
	{
		try
		{
			webClient_0.Headers.Add(DeProtectType.ArgValue_292, DeProtectType.ArgValue_293);
			webClient_0.UploadData(DeProtectType.ArgValue_294 + string_0, DeProtectType.ArgValue_295, byte_0);
		}
		catch (Exception ex)
		{
			FileLogger.Log(DeProtectType.ArgValue_296, DeProtectType.ArgValue_297 + ex.Message);
		}
	}
	private static ImageCodecInfo smethod_1(string string_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length; i++)
		{
			if (imageEncoders[i].MimeType == string_0)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}
	internal static void smethod_2(MemoryStream memoryStream_0)
	{
		try
		{
			using (Bitmap bitmap = ScreenshotService.smethod_3())
			{
				ImageCodecInfo encoder = ScreenshotService.smethod_1(DeProtectType.ArgValue_298);
				Encoder quality = Encoder.Quality;
				EncoderParameters encoderParameters = new EncoderParameters(1);
				EncoderParameter encoderParameter = new EncoderParameter(quality, 50L);
				encoderParameters.Param[0] = encoderParameter;
				bitmap.Save(memoryStream_0, encoder, encoderParameters);
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			FileLogger.Log(DeProtectType.ArgValue_299, DeProtectType.ArgValue_300);
		}
	}
	internal static Bitmap smethod_3()
	{
		Clipboard.Clear();
		HardwareFingerprint.smethod_1(Keys.LControlKey);
		Thread.Sleep(10);
		HardwareFingerprint.smethod_1(Keys.Snapshot);
		Thread.Sleep(10);
		HardwareFingerprint.smethod_2(Keys.Snapshot);
		Thread.Sleep(10);
		HardwareFingerprint.smethod_2(Keys.LControlKey);
		Thread.Sleep(100);
		Bitmap bitmap = null;
		for (;;)
		{
			try
			{
				int num = 0;
				while (num < 20 && !Clipboard.ContainsImage())
				{
					Thread.Sleep(100);
					num++;
				}
				break;
			}
			catch
			{
				Thread.Sleep(100);
			}
		}
		if (!Clipboard.ContainsImage())
		{
			int num2 = Screen.PrimaryScreen.Bounds.Width;
			int x = Control.MousePosition.X;
			num2 = Screen.PrimaryScreen.Bounds.Width * ((int)Math.Ceiling((double)x / (double)num2) - 1);
			bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(num2, 0, 0, 0, bitmap.Size);
				goto IL_131;
			}
		}
		bitmap = (Bitmap)Clipboard.GetImage();
		IL_131:
		Clipboard.Clear();
		return bitmap;
	}
}
