using System;
using System.Drawing;

namespace AthensDefender.Items
{
	/// <summary>
	/// Summary description for Missile.
	/// </summary>
	public class Missile
	{
		private Color _color;
		private Graphics _graphics;
		private float _x, _y;
		private float _slope;
		private float _yIntercept;
		private float _sideLength = 3;
		private bool _hit = false;

		public Missile(Color color, Graphics graphics, float startX, float startY, float slope, float yIntercept)
		{
			this._color = color;
			this._graphics = graphics;	
			this._x = startX;
			this._y = startY;
			this._slope = slope;
			this._yIntercept = yIntercept;
		}

		public void Move(float distance)
		{
			if(_slope > 0)
			{
				distance *= -1;
			}

			if(Math.Abs(_slope) > 3)
			{
				//"slow down" shots that aim nearly vertical
				distance = distance / 5;
			}

			this._x += distance;
			this._y = (_slope * this._x) + _yIntercept;
		}

		public void Render()
		{
			Pen pen = new Pen(_color, 10F);
			GraphicsContext.DrawRectangle(pen, _x, _y, _sideLength, _sideLength);
		}

		public Graphics GraphicsContext
		{
			get { return _graphics; }
		}

		public float X
		{
			get { return _x;}
		}

		public float Y
		{
			get { return _y; }
		}

		public float SideLength
		{
			get { return _sideLength; }
		}

		public bool Hit
		{
			get { return _hit; }
			set { _hit = value; }
		}
	}
}
