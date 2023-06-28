using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeToNextSpawn=5;
    [SerializeField] private Transform enemyContainer;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true) 
        {
            Instantiate(enemyPrefab,enemyContainer);
            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }

}
