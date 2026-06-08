using System;
using System.Runtime.InteropServices;

// Token: 0x02000043 RID: 67
public class GClass32
{
	// Token: 0x06000120 RID: 288
	[DllImport("user32.dll")]
	public static extern int GetAsyncKeyState(int i);
}
