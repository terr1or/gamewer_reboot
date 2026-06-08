using System;
using System.Runtime.InteropServices;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class KeyboardNativeMethods
{
	[DllImport("user32.dll")]
	public static extern int GetAsyncKeyState(int i);
}
