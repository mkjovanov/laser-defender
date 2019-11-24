using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
	[SerializeField] GameObject EnemyPrefab;
	[SerializeField] GameObject PathPrefab;
	[SerializeField] float TimeBetweenSpawns = 0.5f;
	[SerializeField] float SpawnRandomFactor = 0.3f;
	[SerializeField] int NumberOfEnemies = 5;
	[SerializeField] float MoveSpeed = 2f;
	
	public List<Transform> GetWaypoints()
	{
		var waypointList = new List<Transform>();
		foreach(Transform waypoint in PathPrefab.transform)
		{
			waypointList.Add(waypoint);
		}
		return waypointList;
	}

	public GameObject GetEnemyPrefab()
	{
		return EnemyPrefab;
	}
	public GameObject GetPathPrefab()
	{
		return PathPrefab;
	}

	public float GetTimeBetweeenSpawns()
	{
		return TimeBetweenSpawns;
	}

	public float GetSpawnRandomFactor()
	{
		return SpawnRandomFactor;
	}

	public int GetNumberOfEnemies()
	{
		return NumberOfEnemies;
	}

	public float GetMoveSpeed()
	{
		return MoveSpeed;
	}
}