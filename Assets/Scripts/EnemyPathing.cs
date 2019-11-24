using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	
	[SerializeField] WaveConfig WaveConf;
	[SerializeField] float MovementSpeed = 2f;

	private int _currentWaypointIndex = 0;
	private List<Transform> _waypoints;

	// Start is called before the first frame update
	void Start()
	{
		SetStartingPosition();
		_waypoints = WaveConf.GetWaypoints();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	private void SetStartingPosition()
	{
		transform.position = WaveConf.GetWaypoints()[0].transform.position;
	}

	private void Move()
	{
		if (_currentWaypointIndex <= _waypoints.Count - 1)
		{
			var targetPosition = _waypoints[_currentWaypointIndex].transform.position;
			var movement = MovementSpeed * Time.deltaTime;
			this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, movement);
			if (targetPosition.Equals(this.transform.position))
			{
				_currentWaypointIndex++;
			}
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
