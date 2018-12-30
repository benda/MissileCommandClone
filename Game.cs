using System;
using System.Windows.Forms;

namespace AthensDefender
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game
	{
		private Game()
		{
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			SplashScreen splashScreen = null;
			GameEngine engine = null;
			try
			{
				splashScreen = new SplashScreen();
				splashScreen.ShowDialog();
				splashScreen.Close();
				splashScreen.Dispose();
				engine = new GameEngine();
				Application.EnableVisualStyles();
				Application.Run(engine);
			}
			finally
			{
				if(splashScreen != null)
				{
					splashScreen.Dispose();
				}

				if(engine != null)
				{
					engine.Dispose();
				}
			}
		}
	}
}
