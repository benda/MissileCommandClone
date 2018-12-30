using System;

namespace AthensDefender.Frames
{
	/// <summary>
	/// 
	/// </summary>
	public class FrameRate
	{
		private static int lastTick;
		private static int lastFrameRate;
		private static int frameRate;

		private FrameRate()
		{
		}

		public static int CalculateFrameRate()
		{
			if (System.Environment.TickCount - lastTick >= 1000)
			{
				lastFrameRate = frameRate;
				frameRate = 0;
				lastTick = System.Environment.TickCount;
			}
			frameRate++;
			return lastFrameRate;
		}


	}
}
