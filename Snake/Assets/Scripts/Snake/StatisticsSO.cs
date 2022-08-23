using UnityEngine;

namespace Snake
{
	[CreateAssetMenu(menuName = "Statistics", fileName = "new Statisctic")]
	public class StatisticsSO : ScriptableObject
	{
		[SerializeField] private bool isCrushingWall;
		[SerializeField] private bool isGamePaused;
		[SerializeField] private bool isAlive;
		[SerializeField] private float normalTime;
		[SerializeField] private float speedUpTime;
		[SerializeField] private float slowDownTime;
		[SerializeField] private float freezeTime;
		[SerializeField] private float effectDuration;

		private float storedTime;

		public float NormalTime => normalTime;
		public float SpeedUpTime => speedUpTime;
		public float SlowDownTime => slowDownTime;
		public float FreezeTime => freezeTime;
		public float EffectDuration => effectDuration;
		public bool IsCrushingWall
		{
			get { return isCrushingWall; }
			set { isCrushingWall = value; }
		}
		public bool IsGamePaused
		{
			get { return isGamePaused; }
			set { isGamePaused = value; }
		}
		public bool IsAlive
		{
			get { return isAlive; }
			set { isAlive = value; }
		}

		public float StoredTime
		{
			get { return storedTime; }
			set { storedTime = value; }
		}
	}
}
