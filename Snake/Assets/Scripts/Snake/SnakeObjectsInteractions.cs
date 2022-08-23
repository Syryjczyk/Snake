using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
	public class SnakeObjectsInteractions : MonoBehaviour
	{
		public Vector3 ResetPosition()
		{
			return Vector3.zero;
		}

		public Vector3 ThroughHorizontalWalls(Vector3 snakePosition, Vector3 wallPosition)
		{
			if (snakePosition.y > 0)
			{
				return new Vector3(snakePosition.x, (wallPosition.y - 1) * -1, snakePosition.z);
			}
			else
			{
				return new Vector3(snakePosition.x, wallPosition.y - 1, snakePosition.z);
			}
		}

		public Vector3 ThroughVerticalWalls(Vector3 snakePosition, Vector3 wallPosition)
		{
			if (snakePosition.x > 0)
			{
				return new Vector3((wallPosition.x - 1) * - 1, snakePosition.y, snakePosition.z);
			}
			else
			{
				return new Vector3(wallPosition.x - 1, snakePosition.y, snakePosition.z);
			}
		}

		public void RemoveTheTail(List<Transform> snakeSegmentsList)
		{
			for (int i = 1; i < snakeSegmentsList.Count; i++)
			{
				Destroy(snakeSegmentsList[i].gameObject);
			}

			snakeSegmentsList.RemoveRange(1, snakeSegmentsList.Count - 1);
		}
	}
}

