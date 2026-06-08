using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class RetryScheduler
{
	private RetryScheduler()
	{
	}
	private void method_0()
	{
		ThreadPool.QueueUserWorkItem(new WaitCallback(this.method_2));
	}
	internal void method_1()
	{
		this.bool_1 = true;
	}
	internal static RetryScheduler RunForever(Action action_2, Action<Exception> action_3, float float_0)
	{
		RetryScheduler gclass = new RetryScheduler();
		gclass.action_0 = action_2;
		gclass.action_1 = action_3;
		gclass.timeSpan_0 = TimeSpan.FromMilliseconds((double)(float_0 * (float)int.Parse(DeProtectType.ArgValue_381)));
		gclass.method_0();
		return gclass;
	}
	internal static RetryScheduler RunForeverDelayed(Action action_2, Action<Exception> action_3, float float_0)
	{
		RetryScheduler gclass = new RetryScheduler();
		gclass.action_0 = action_2;
		gclass.timeSpan_0 = TimeSpan.FromMilliseconds((double)(float_0 * (float)int.Parse(DeProtectType.ArgValue_382)));
		gclass.action_1 = action_3;
		gclass.bool_0 = true;
		gclass.method_0();
		return gclass;
	}
	[CompilerGenerated]
	private void method_2(object object_0)
	{
		while (!this.bool_1)
		{
			Thread.Sleep(this.timeSpan_0);
			RuntimeGuard.EnqueueOnMainLoop(new Action(this.method_3));
			if (!this.bool_0)
			{
				break;
			}
		}
	}
	[CompilerGenerated]
	private void method_3()
	{
		try
		{
			Action action = this.action_0;
			if (action != null)
			{
				action();
			}
		}
		catch (Exception obj)
		{
			Action<Exception> action2 = this.action_1;
			if (action2 != null)
			{
				action2(obj);
			}
		}
	}
	private Action action_0;
	private Action<Exception> action_1;
	private TimeSpan timeSpan_0;
	private bool bool_0 = false;
	private bool bool_1 = false;
}
