using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeToNextSpawn=5;
    [SerializeField] private Transform enemyContainer;

    private bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {

        while (!stopSpawning) 
        {
            Instantiate(enemyPrefab,enemyContainer);
            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }

    public void onPlayerDeath()
    {
        stopSpawning = true;
    }
}
