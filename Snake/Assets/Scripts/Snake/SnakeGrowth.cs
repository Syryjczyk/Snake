using System.Collections.Generic;
using UnityEngine;

namespace Snake 
{
	public class SnakeGrowth
	{
		public void Grow(List<Transform> snakeSegmentsList, Transform snakeSegment)
		{
			snakeSegment.position = snakeSegmentsList[snakeSegmentsList.Count - 1].position;
			snakeSegmentsList.Add(snakeSegment);
		}

		public void FollowTheHead(List<Transform> snakeSegmentsList)
		{
			for (int i = snakeSegmentsList.Count - 1; i > 0; i--)
			{
				snakeSegmentsList[i].position = snakeSegmentsList[i - 1].position;
			}
		}
	}
}


