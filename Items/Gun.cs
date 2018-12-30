using System;
using System.Drawing;

namespace AthensDefender.Items
{
	/// <summary>
	/// Summary description for Gun.
	/// </summary>
	public class Gun
	{
		private Graphics _graphics;
		private float _gunStartX = 410;
		private float _gunStartY = 450;
		private float _windowHeight;
		private float _gunLength = 50F;

		public Gun(Graphics graphics, float windowHeight)
		{
			this._graphics = graphics;
			this._windowHeight = windowHeight;
		}

		public void Render()
		{
			Pen pen = new Pen(Color.LightGray, 10F);
			Point top = new Point((int)_gunStartX, (int)_gunStartY);
			Point bottomLeft = new Point((int) (_gunStartX - _gunLength), (int) (_gunStartY + _gunLength));
			Point bottomRight = new Point((int)(_gunStartX + _gunLength), (int)(_gunStartY + _gunLength));

			_graphics.DrawLine(pen, bottomLeft, top);
			_graphics.DrawLine(pen, bottomRight, top);
			_graphics.DrawLine(pen, bottomLeft, bottomRight);
			
			/*
			Font font = new Font("Arial", 12F);
			Brush brush = new SolidBrush(Color.Green);
			_graphics.DrawString(mouseX.ToString() + " " + mouseY.ToString() + " " + slope.ToString(), font, brush, mouseX, mouseY);
			*/
	
			}

		public float StartX
		{
			get { return (int) _gunStartX; }
		}

		public float StartY
		{
			get { return (int) _gunStartY; }
		}
	}
}
