using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AthensDefender.Items;
using AthensDefender.Detectors;
using AthensDefender.Frames;
using AthensDefender.Util;

namespace AthensDefender
{
	/// <summary>
	/// 
	/// </summary>
	public class GameEngine : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private int _delay = 100;
		private int _missileSpeed = 10;	
		private float _mouseX;
		private float _mouseY;
		private Graphics _graphics = null;
		private Score _score;
		private Health _health;
		private RecylingArray _blocks;
		private RecylingArray _missiles;
		private RecylingArray _collisions;
		private Gun _gun = null;

		public GameEngine()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
			this.Size = new Size ( 800, 600 );
			_graphics = this.CreateGraphics();

			_blocks = new RecylingArray( 50 );
			_missiles = new RecylingArray( 50 );
			_collisions = new RecylingArray( 10 );

			_gun = new Gun(GraphicsContext, this.Height);
			_score = new Score(GraphicsContext, this.Width);
			_health = new Health(GraphicsContext, this.Width);
		}

		protected override void OnPaint(PaintEventArgs e)
		{		
			this.Text = string.Format("The framerate is {0}", FrameRate.CalculateFrameRate());
			e.Graphics.Clear(Color.Black);
			
			//add a new block
			Random random = new Random();
			if(random.Next(0, 40) == 1)
			{
				BlockType blockType;

				if(random.Next(0, 10) == 1)
				{
					blockType = BlockType.Bonus1;
				}
				else
				{
					blockType = BlockType.Enemy1;
				}

				_blocks.Add( new Block(GraphicsContext, random.Next(100, 700), random.Next(20, 100), blockType));
			}

			//update all block positions on screen
			foreach(Block block in _blocks)
			{
				if(!block.Hit)
				{
					block.MoveDown(2);
					block.Render();
				
				if(OffScreenDetector.OffScreen(block.Y, this.Height))
				{
					block.Hit = true;
					_health.RecordBlockHit(1);

					if(_health.IsDead)
					{
						Font font = new Font("Arial", 20F);
						Brush brush = new SolidBrush(Color.Red);
						_graphics.DrawString("Health is 0! Game Over!", font, brush, this.Width/2, this.Height/2);
						System.Threading.Thread.Sleep(2000);
						Exit();
					}
				}

				}
			}

			foreach(Missile missile in _missiles)
			{
				if(!missile.Hit)
				{
					missile.Move(_missileSpeed);
					missile.Render();
				}
			}

			//detect collisions
			bool wasCollision = false;
			foreach(Block block in _blocks)
			{
				if(!wasCollision)
				{

					if(block.Hit)
					{
						continue;
					}

					foreach(Missile missile in _missiles)
					{
						if(!missile.Hit)
						{
							if(CollisionDetector.Collision(missile, block))
							{
								_collisions.Add( new Collision( GraphicsContext, block.X, block.Y));
								wasCollision = true;						
								missile.Hit = true;
								block.Hit = true;

								switch(block.Type)
								{		
									case BlockType.Bonus1:
										_missileSpeed += 2;
									break;

									case BlockType.Bonus2:
										_score.RecordHit(10);
									break;

									case BlockType.Enemy1:
										_score.RecordHit(1);
									break;

									case BlockType.Enemy2:
										_score.RecordHit(2);
									break;
								}
								
							}
						}
					}
				}
			}

			foreach(Collision collision in _collisions)
			{
				if(collision.RenderTimes < 20)
				{
					collision.Render();
				}
			}
			
			_health.Render();
			_score.Render();
			_gun.Render();

			System.Threading.Thread.Sleep(_delay);
		    this.Invalidate();
  		}

		private void GameEngine_MouseMove(object sender, MouseEventArgs e)
		{
			_mouseX = e.X;
			_mouseY = e.Y;
		}

		private void GameEngine_Click(object sender, EventArgs e)
		{
			float slope = (_mouseY - _gun.StartY) / (_mouseX - _gun.StartX);
			float yIntercept = _gun.StartY - (slope * _gun.StartX);
			if(!float.IsInfinity(yIntercept))
			{
				_missiles.Add( new Missile(Color.MediumBlue, GraphicsContext, _gun.StartX, 500, slope, yIntercept));
			}
		}

		private void GameEngine_KeyUp(object sender, KeyEventArgs e)
		{
			string message = string.Empty;

			if(e.KeyCode == Keys.C)
			{
				message = "Collision Mode: " + CollisionDetector.ToggleCollisionMode();
			}

			if(e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Oemplus)
			{
				//adjust game delay (= game speed)
				if(e.KeyCode == Keys.OemMinus)
				{
					if(_delay < 1000)
					{
						_delay += 10;	
					}
				}

				if(e.KeyCode == Keys.Oemplus)
				{
					if(_delay > 0)
					{
						_delay -= 10;
					}
				}
				
				message = "Game Speed: " + (1000 - _delay).ToString();
			}

			Font font = new Font("Arial", 14F);
			Brush brush = new SolidBrush(Color.White);
			_graphics.DrawString(message, font, brush, this.Width/2 - 50, this.Height/2);
			System.Threading.Thread.Sleep(200);
		}
	
		public void Exit()
		{
			Application.Exit();
		}

		public Graphics GraphicsContext
		{
			get 
			{
				return _graphics;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
				GraphicsContext.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// GameEngine
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "GameEngine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GameEngine";
			this.MouseMove +=new MouseEventHandler(GameEngine_MouseMove);
			this.Click +=new EventHandler(GameEngine_Click);
			this.KeyUp +=new KeyEventHandler(GameEngine_KeyUp);
		}
		#endregion
	}
}
