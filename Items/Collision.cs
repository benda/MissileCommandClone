using System;
using System.Drawing;

namespace AthensDefender.Items
{
	/// <summary>
	/// Collision
	/// </summary>
	public class Collision
	{
		private Graphics _graphics;
		private float _x, _y;
		private uint _renderTimes = 0;
		private uint _maxRenderTimes = 20;
		private uint _halfMaxRenderTimes = 10;
		public Collision(Graphics graphics, float x, float y)
		{
			this._graphics = graphics;	
			this._x = x;
			this._y = y;
		}

		public void Render()
		{
			if(_renderTimes <= _maxRenderTimes)
			{
				Pen pen = new Pen(Color.SandyBrown, 10F);
				if(_renderTimes <= _halfMaxRenderTimes)
				{
					_graphics.DrawEllipse(pen, _x, _y, _renderTimes, _renderTimes);
				}
				else
				{
					_graphics.DrawEllipse(pen, _x, _y, _maxRenderTimes - _renderTimes, _maxRenderTimes - _renderTimes);		
				}
				_renderTimes++;
			}
		}

		public uint RenderTimes
		{
			get { return _renderTimes; }
		}
	}
}
