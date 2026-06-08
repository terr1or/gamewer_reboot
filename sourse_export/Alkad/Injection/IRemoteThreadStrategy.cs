using System;
/// <summary>
/// Provides the interface component for the GameWer client.
/// </summary>
internal interface IRemoteThreadStrategy
{
	IntPtr Inject(IntPtr processHandle, string dllPath);
}
