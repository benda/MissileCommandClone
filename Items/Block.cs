using System;
using System.Drawing;
using System.Windows.Forms;

namespace AthensDefender.Items
{
	public enum BlockType
	{
		Enemy1 = 1,
		Enemy2 = 2,
		Bonus1 = 3,
		Bonus2 = 4,
	}
	/// <summary>
	/// Block
	/// </summary>
	public class Block
	{
		private Color _color;
		private Graphics _graphics;
		private float _x, _y;
		private float _sideLength = 10;
		private bool _hit = false;
		private BlockType _type;

		public Block(Graphics graphics, float x, float y, BlockType type)
		{
			if(type == BlockType.Bonus1 || type == BlockType.Bonus2)
			{
				this._color = Color.Aqua;
			}
			else
			{
				this._color = Color.Red;
			}
			this._graphics = graphics;	
			this._x = x;
			this._y = y;
			this._type = type;
		}

		public void MoveDown(float y)
		{
			this._y += y;
		}

		public void Render()
		{
			Pen pen = new Pen(_color, 10F);
			GraphicsContext.DrawRectangle(pen, _x, _y, _sideLength, _sideLength);
		}

		public BlockType Type
		{
			get { return _type; }
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
			get { return _hit;}
			set { _hit = value; }
		}

	}
}
