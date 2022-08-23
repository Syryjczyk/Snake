using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Snake
{
	public class SnakeController : MonoBehaviour
	{
		#region variables

		[SerializeField] private StatisticsSO snakeStatistics;
		[SerializeField] private TextMeshProUGUI scoreText;
		[SerializeField] private TextMeshProUGUI yourScoreText;
		[SerializeField] private Transform snakeSegment;
		[SerializeField] private Transform horizontalWall;
		[SerializeField] private Transform verticalWall;
		[Header("Events")]
		[SerializeField] private GameEvent onAppleEat;
		[SerializeField] private GameEvent onBonusAppleEat;
		[SerializeField] private GameEvent onLiveLoss;
		[SerializeField] private GameEvent onScore;

		private SnakeMovement snakeMovement;
		private SnakeMapController snakeMapController;
		private SnakeObjectsInteractions snakeObjectsInteractions;
		private SnakeGrowth snakeGrowth;
		private List<Transform> snakeSegmentsList;

		#endregion

		#region unity methods

		private void Awake()
		{
			snakeMovement = new SnakeMovement();
			snakeMapController = new SnakeMapController();
			snakeGrowth = new SnakeGrowth();
			snakeObjectsInteractions = GetComponent<SnakeObjectsInteractions>();
			snakeSegmentsList = new List<Transform>();
		}

		private void OnEnable()
		{
			snakeMapController.Enable();
			snakeMapController.SnakeActions.Movement.performed += snakeMovement.Move;
		}

		private void Start()
		{
			Time.timeScale = snakeStatistics.NormalTime;
			transform.position = Vector3.zero;
			snakeSegmentsList.Add(transform);
			snakeStatistics.IsCrushingWall = true;
			ShowScore();
			onAppleEat?.Invoke();
			
		}

		private void OnDisable()
		{
			snakeMapController.Disable();
		}
		private void FixedUpdate()
		{
			snakeGrowth.FollowTheHead(snakeSegmentsList);

			transform.position = new Vector3(
				Mathf.Round(transform.position.x) + snakeMovement.Direction.x,
				Mathf.Round(transform.position.y) + snakeMovement.Direction.y,
				0.0f);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			switch (collision.gameObject.tag)
			{
				case "Snake":
					gameObject.transform.position = snakeObjectsInteractions.ResetPosition();
					snakeObjectsInteractions.RemoveTheTail(snakeSegmentsList);
					Time.timeScale = snakeStatistics.NormalTime;
					snakeStatistics.IsCrushingWall = true;
					onLiveLoss?.Invoke();
					break;
				case "CrashWalls":
					snakeStatistics.IsCrushingWall = true;
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onBonusAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				case "DoublePoint":
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onBonusAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				case "SlowDown":
					StartCoroutine(TimeManager(snakeStatistics.SlowDownTime, snakeStatistics.EffectDuration));
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onBonusAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				case "SpeedUp":
					StartCoroutine(TimeManager(snakeStatistics.SpeedUpTime, snakeStatistics.EffectDuration));
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onBonusAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				case "ThroughTheWalls":
					snakeStatistics.IsCrushingWall = false;
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onBonusAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				case "Apple":
					snakeGrowth.Grow(snakeSegmentsList, Instantiate(snakeSegment));
					Vibrator.Vibrate();
					onAppleEat?.Invoke();
					onScore?.Invoke();
					break;
				default:
					break;
			}

			if (collision.gameObject.tag == "Obstacle Horizontal" || collision.gameObject.tag == "Obstacle Vertical")
			{
				switch (snakeStatistics.IsCrushingWall)
				{
					case false:
						switch (collision.gameObject.tag)
						{
							case "Obstacle Horizontal":
								gameObject.transform.position = snakeObjectsInteractions.ThroughHorizontalWalls(gameObject.transform.position, horizontalWall.position);
								break;
							case "Obstacle Vertical":
								gameObject.transform.position = snakeObjectsInteractions.ThroughVerticalWalls(gameObject.transform.position, verticalWall.position);
								break;
							default:
								break;
						}
						break;

					case true:
						gameObject.transform.position = snakeObjectsInteractions.ResetPosition();
						snakeObjectsInteractions.RemoveTheTail(snakeSegmentsList);
						Time.timeScale = snakeStatistics.NormalTime;
						onLiveLoss?.Invoke();
						break;
				}
			}
		}

		#endregion

		#region public methods

		public void ShowScore()
		{
			scoreText.text = $"Score:\n{(snakeSegmentsList.Count - 1) * 10}";
			yourScoreText.text = $"Your score: {(snakeSegmentsList.Count - 1) * 10}";
		}

		#endregion

		#region private methods

		private IEnumerator TimeManager(float getTime, float effectDuration)
		{
			Time.timeScale = getTime;
			snakeStatistics.StoredTime = getTime;


			yield return new WaitForSeconds(effectDuration);

			Time.timeScale = snakeStatistics.NormalTime;
			snakeStatistics.StoredTime = snakeStatistics.NormalTime;
		}

		

		#endregion
	}
}

