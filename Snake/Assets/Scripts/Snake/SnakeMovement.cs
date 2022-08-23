using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake
{
	public class SnakeMovement
	{
		private Touchscreen touch;
		private Vector3 direction;
		private bool horizontal = true;
		private bool vertical = true;



		public Vector3 Direction => direction;

		public void Move(InputAction.CallbackContext context)
		{
			touch = new Touchscreen();
			if (!context.ReadValue<Vector3>().Equals(Vector3.zero))
			{
				if (context.ReadValue<Vector3>().Equals(Vector3.up) && vertical)
				{
					direction = Vector3.up;
					horizontal = true;
					vertical = false;
				}
					
				else if (context.ReadValue<Vector3>().Equals(Vector3.down) && vertical)
				{
					direction = Vector3.down;
					horizontal = true;
					vertical = false;
				}
					
				else if (context.ReadValue<Vector3>().Equals(Vector3.right) && horizontal)
				{
					direction = Vector3.right;
					horizontal = false;
					vertical = true;
				}
					
				else if (context.ReadValue<Vector3>().Equals(Vector3.left) && horizontal)
				{
					direction = Vector3.left;
					horizontal = false;
					vertical = true;
				}
					
			}

		}
	}
}


