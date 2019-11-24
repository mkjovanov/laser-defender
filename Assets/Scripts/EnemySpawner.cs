using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] List<WaveConfig> WaveConfigs;
	private int _startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
		var currentWave = WaveConfigs[_startingWave];
		StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

	private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
	{
		for (int enemyCount = 0; enemyCount < currentWave.GetNumberOfEnemies(); enemyCount++)
		{
			Instantiate(
				currentWave.GetEnemyPrefab(), 
				currentWave.GetWaypoints()[0].transform.position, 
				Quaternion.identity);
			yield return new WaitForSeconds(currentWave.GetTimeBetweeenSpawns());
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
