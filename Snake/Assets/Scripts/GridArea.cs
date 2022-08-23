using UnityEngine;

public class GridArea : MonoBehaviour
{
	[SerializeField] private BoxCollider2D gridArea;
	public Vector3 GetRandomVector()
	{
		var bounds = gridArea.bounds;

		var x = Random.Range(bounds.min.x, bounds.max.x);
		var y = Random.Range(bounds.min.y, bounds.max.y);

		return new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
	}
}
