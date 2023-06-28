using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Borders and spawn position")]
    [SerializeField] float horizontalAbsBorder = 11.3f;
    [SerializeField] float respawnYPos = 5.8f;
    [Header("Enemy Spawner")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float timeToNextEnemySpawn = 5;
    [SerializeField] private Transform enemyContainer;
    [Header("Powerups Spawner")]
    [SerializeField] private Powerup powerupPrefab;
    [SerializeField] private float averageTimeToNextPowerupSpawn = 7;
    [SerializeField]
    [Range(0f, 10f)] private float meanDeviationOfSpawnTime = 2.5f;

    private GameObject spawnedObject;
    private bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupsRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (!stopSpawning)
        {
            spawnedObject = Instantiate(enemyPrefab.gameObject, enemyContainer);
            spawnedObject.transform.position = new Vector3(Random.Range(-horizontalAbsBorder, horizontalAbsBorder), respawnYPos, 0);
            yield return new WaitForSeconds(timeToNextEnemySpawn);
        }
    }

    IEnumerator SpawnPowerupsRoutine()
    {
        while (!stopSpawning)
        {
            spawnedObject = Instantiate(powerupPrefab.gameObject);
            spawnedObject.transform.position = new Vector3(Random.Range(-horizontalAbsBorder, horizontalAbsBorder), respawnYPos, 0);
            yield return new WaitForSeconds(Random.Range(
                averageTimeToNextPowerupSpawn - meanDeviationOfSpawnTime,
                averageTimeToNextPowerupSpawn + meanDeviationOfSpawnTime));
        }
    }

    public void onPlayerDeath()
    {
        stopSpawning = true;
    }
}
