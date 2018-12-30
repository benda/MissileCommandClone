using System;
using AthensDefender.Items;

namespace AthensDefender.Detectors
{

	/// <summary>
	/// CollisionDetector.
	/// </summary>
	public class CollisionDetector
	{
		private enum CollisionMode
		{
			Inside, //must get missile 100% inside of block
			Touch, //missile just needs to touch the block
		}


		private static CollisionMode _collisionMode = CollisionMode.Touch;

		private CollisionDetector()
		{
		}

		public static bool Collision(Missile missile, Block block)
		{
			if(_collisionMode == CollisionMode.Inside)
			{				 
				return
					((missile.X + missile.SideLength) >= block.X)  
					&& ((missile.X + missile.SideLength) <= (block.X + block.SideLength)) 

					&& ((missile.Y + missile.SideLength) >= block.Y)
					&& ((missile.Y + missile.SideLength) <= (block.Y + block.SideLength));
			}
			else
			{
				//return missile.X > block.X && missile.Y < (block.Y + block.SideLength);
				return
					((missile.X + missile.SideLength) >= block.X )  
					&& ((missile.X + missile.SideLength) <= (block.X + (block.SideLength *3) )) 

					&& ((missile.Y + missile.SideLength) >= block.Y)
					&& ((missile.Y + missile.SideLength) <= (block.Y + (block.SideLength *3)));
		
			}
		}

		public static string ToggleCollisionMode()
		{
			if(_collisionMode == CollisionMode.Inside)
			{
				_collisionMode = CollisionMode.Touch;
			}
			else
			{
				_collisionMode = CollisionMode.Inside;
			}

			return _collisionMode.ToString();
		}
	}
}
