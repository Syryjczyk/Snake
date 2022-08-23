using UnityEngine;

public class FitRootToCamera : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private float zAxisOffset;

	private void Start()
	{
		mainCamera = GetComponent<Camera>();
		transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, zAxisOffset);

		var bottomLeft = mainCamera.ViewportToWorldPoint(Vector3.zero) * 100;
		var topRight = mainCamera.ViewportToWorldPoint(new Vector3(mainCamera.rect.width, mainCamera.rect.height)) * 100;
		var screenSize = topRight - bottomLeft;
		var screenRatio = screenSize.x / screenSize.y;
		var desiredRatio = transform.localScale.x / transform.localScale.y;

		if (screenRatio > desiredRatio)
		{
			var height = screenSize.y;
			transform.localScale = new Vector3(height * desiredRatio, height);
		}
		else
		{
			var width = screenSize.x;
			transform.localScale = new Vector3(width, width / desiredRatio);
		}
	}
}
