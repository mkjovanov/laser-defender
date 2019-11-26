using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	
	WaveConfig _waveConf;
	private int _currentWaypointIndex = 0;
	private List<Transform> _waypoints;

	// Start is called before the first frame update
	void Start()
	{
		SetStartingPosition();
		_waypoints = _waveConf.GetWaypoints();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	private void SetStartingPosition()
	{
		transform.position = _waveConf.GetWaypoints()[0].transform.position;
	}

	public void SetEnemyConfig(WaveConfig waveConfig)
	{
		this._waveConf = waveConfig;
	}

	private void Move()
	{
		if (_currentWaypointIndex <= _waypoints.Count - 1)
		{
			var targetPosition = _waypoints[_currentWaypointIndex].transform.position;
			var movement = _waveConf.GetMoveSpeed() * Time.deltaTime;
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
