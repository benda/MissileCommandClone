using System;

namespace AthensDefender.Detectors
{
	/// <summary>
	///  OffScreenDetector.
	/// </summary>
	public class OffScreenDetector
	{
		private OffScreenDetector()
		{
			
		}

		public static bool OffScreen(float objectY, int windowHeight)
		{
			return objectY > windowHeight;
		}
	}
}
