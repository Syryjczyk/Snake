using UnityEngine;

public class AppleController : MonoBehaviour
{
	[SerializeField] private BonusApplesSO bonusApples;
	
	private GridArea gridArea;
	private Transform bonusApple;
	private float timer;

	private void Awake()
	{
		gridArea = FindObjectOfType<GridArea>();
		timer = bonusApples.Timer;
		bonusApples.IsReadyToSpawnBonusApple = true;
	}

	private void Update()
	{
		timer -= Time.deltaTime;

		if (timer < 0.0f)
		{
			if (bonusApples.IsReadyToSpawnBonusApple)
			{
				GetBonusApple();
			}
			else
			{
				DestroyBonusApple();
			}

			timer = bonusApples.Timer;
		}
	}

	public void SetNewPosition()
	{
		transform.position = gridArea.GetRandomVector();
	}

	private void GetBonusApple()
	{
		var randomIndex = Random.Range(0, bonusApples.BonusApplesList.Count);

		bonusApple = Instantiate(bonusApples.BonusApplesList[randomIndex]);
		bonusApple.transform.position = gridArea.GetRandomVector();
		bonusApples.IsReadyToSpawnBonusApple = false;
	}

	private void DestroyBonusApple()
	{
		Destroy(bonusApple.gameObject);
		bonusApples.IsReadyToSpawnBonusApple = true;
	}
}
