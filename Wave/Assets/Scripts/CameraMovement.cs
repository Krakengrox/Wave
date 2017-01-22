using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

	public Transform target;

	public float distance = -10f;

	public float height = 0f;

	public float damping = 5.0f;

	public float mapX = 100.0f;
	public float mapY = 100.0f;

	private float minX = 0f;
	private float maxX = 0f;
	private float minY = 0f;
	private float maxY = 0f;

	void Start()
	{
		Vector3 wantedPosition = target.TransformPoint(0, height, distance);
		Debug.Log(wantedPosition);

		minX = transform.position.x;
		minY = transform.position.y;

		maxX = mapX;
		maxY = mapY;
	}

	void Update()
	{

		Vector3 wantedPosition = target.TransformPoint(0, height, distance);

		wantedPosition.x = (wantedPosition.x < minX) ? minX : wantedPosition.x;
		wantedPosition.x = (wantedPosition.x > maxX) ? maxX : wantedPosition.x;

		wantedPosition.y = (wantedPosition.y < minY) ? minY : wantedPosition.y;
		wantedPosition.y = (wantedPosition.y > maxY) ? maxY : wantedPosition.y;

		transform.position = Vector3.Lerp(transform.position, wantedPosition, (Time.deltaTime * damping));
	}

}