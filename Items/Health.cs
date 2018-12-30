using System;
using System.Drawing;

namespace AthensDefender.Items
{
	/// <summary>
	/// Summary description for Health.
	/// </summary>
	public class Health
	{
		private Graphics _graphics;
		private int _health = 10;
		private int _gameWindowWidth = 0;

		public Health(Graphics graphics, int gameWindowWidth)
		{
			this._graphics = graphics;
			this._gameWindowWidth = gameWindowWidth;
		}

		public void Render()
		{
			Font font = new Font("Arial", 10F);
			Brush brush = new SolidBrush(Color.White);
			_graphics.DrawString("Health: " + _health.ToString(), font, brush, _gameWindowWidth - 100, 100);
		}

		public void RecordBlockHit(int hits)
		{
			_health -= hits;
		}

		public bool IsDead
		{
			get { return _health == 0; }
		}
	}
}
