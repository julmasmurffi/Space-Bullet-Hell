using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //we will loop enemy waves here
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int indexOfWaves = startingWave; indexOfWaves < waveConfigs.Count; indexOfWaves++)
        {
            var currentWave = waveConfigs[indexOfWaves];
            yield return StartCoroutine(SpawnAllEnemyWaves(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemyWaves(WaveConfig waveConfig)
    {
        for (int numOfEnemies = 0; numOfEnemies < waveConfig.GetNumOfEnemies(); numOfEnemies++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            //feeding the local wave config to the enemy pathing script
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()
            );
        }
    }
}
