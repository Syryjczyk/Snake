using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus Apples", fileName = "Bonus Apples")]
public class BonusApplesSO : ScriptableObject
{
	[SerializeField] private float timer;
	[SerializeField] private bool isReadyToSpawnBonusApple = true;
	[SerializeField] private List<Transform> bonusApplesList;

	public List<Transform> BonusApplesList => bonusApplesList;
	public float Timer => timer;
	public bool IsReadyToSpawnBonusApple
	{
		get { return isReadyToSpawnBonusApple; }
		set { isReadyToSpawnBonusApple = value; }
	}
}
