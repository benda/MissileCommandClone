using System;
using System.Drawing;

namespace AthensDefender.Items
{
	/// <summary>
	///  Score
	/// </summary>
	public class Score
	{
		private Graphics _graphics;
		private int _numHits = 0;
		private int _gameWindowWidth = 0;

		public Score(Graphics graphics, int gameWindowWidth)
		{
			this._graphics = graphics;
			this._gameWindowWidth = gameWindowWidth;
		}

		public void Render()
		{
			Font font = new Font("Arial", 10F);
			Brush brush = new SolidBrush(Color.White);
			_graphics.DrawString("Score: " + _numHits.ToString(), font, brush, _gameWindowWidth - 100, 50);
		}

		public void RecordHit(int hits)
		{
			_numHits += hits;
		}
	}
}
