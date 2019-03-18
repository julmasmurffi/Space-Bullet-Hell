using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomizer = 0.2f;
    [SerializeField] int numOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    //getters for other classes
    public GameObject GetEnemyPrefab(){ return enemyPrefab; }
    public GameObject GetPathPrefab() { return pathPrefab; }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomizer() { return spawnRandomizer; }
    public int GetNumOfEnemies() { return numOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
}
