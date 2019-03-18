using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemyWaves(currentWave));
    }

    private IEnumerator SpawnAllEnemyWaves(WaveConfig waveConfig)
    {
        for (int numOfEnemies = 0; numOfEnemies < waveConfig.GetNumOfEnemies(); numOfEnemies++)
        {
            Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()
            );
        }
    }
}
