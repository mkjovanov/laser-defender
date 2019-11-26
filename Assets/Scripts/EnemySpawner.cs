using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] List<WaveConfig> WaveConfigs;
	[SerializeField] private int StartingWave = 0;
	[SerializeField] private bool Looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
		do
		{
			yield return StartCoroutine(SpawnAllWaves());
		} 
		while (Looping);
    }

	private IEnumerator SpawnAllWaves()
	{
		for (int waveIndex = StartingWave; waveIndex < WaveConfigs.Count; waveIndex++)
		{
			var currentWave = WaveConfigs[waveIndex];
			yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
		}
	}

	private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
	{
		for (int enemyCount = 0; enemyCount < currentWave.GetNumberOfEnemies(); enemyCount++)
		{
			var newEnemy = Instantiate(
				currentWave.GetEnemyPrefab(), 
				currentWave.GetWaypoints()[0].transform.position, 
				Quaternion.identity);
			newEnemy.GetComponent<EnemyPathing>().SetEnemyConfig(currentWave);
			yield return new WaitForSeconds(currentWave.GetTimeBetweeenSpawns());
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
