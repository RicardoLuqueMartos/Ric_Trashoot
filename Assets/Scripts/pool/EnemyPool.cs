using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    #region Variables
    [SerializeField]
    float spawnFrequency = 1f;

    [SerializeField]
    int maxEnemiesCount = 1;

    [SerializeField]
    int maxEnemiesCountToSpawn = 1;

    [SerializeField]
    GameObject poolObject;

    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    List<GameObject> allEnemiesList = new List<GameObject>();

    [SerializeField]
    List<GameObject> availableEnemiesList = new List<GameObject>();

    [SerializeField]
    List<GameObject> deployedEnemiesList = new List<GameObject>();

    [SerializeField]
    List<GameObject> allEnemiesSpawnersList = new List<GameObject>();

    [SerializeField]
    List<GameObject> enemiesSpawnersList = new List<GameObject>();

    [SerializeField]
    List<GameObject> usedSpawnersList = new List<GameObject>();
    #endregion Variables

    public void ResetPool()
    {
        ResetSpawnersLists();
        ResetEnemiesLists();
    }

    void ResetSpawnersLists()
    {
        enemiesSpawnersList = new List<GameObject>(allEnemiesSpawnersList);
        usedSpawnersList.Clear();
    }

    void ResetEnemiesLists()
    {
        ResetEnemies();
        availableEnemiesList = new List<GameObject>(allEnemiesList);
        deployedEnemiesList.Clear();
    }

    void ResetEnemies()
    {
        for (int i = 0; i < allEnemiesList.Count; i++)
        {
            allEnemiesList[i].SetActive(false);
        }
    }

    void OnEnable()
    {
        ResetPool();

        StartPool();
    }

    public void StartPool()
    {
        InvokeRepeating("SpawnEnemyAtFrequency", spawnFrequency, spawnFrequency);
    }

    public void StopPool()
    {
        CancelInvoke("SpawnEnemyAtFrequency");
    }

    private void LateUpdate()
    {
        if (playerObject != null)      
            poolObject.transform.position = playerObject.transform.position;
    }

    void SpawnEnemyAtFrequency()
    {
        if (availableEnemiesList.Count > 0)
        {
            if (maxEnemiesCount >= availableEnemiesList.Count)           
                maxEnemiesCountToSpawn = UnityEngine.Random.Range(1, availableEnemiesList.Count);
            else maxEnemiesCountToSpawn = UnityEngine.Random.Range(1, maxEnemiesCount);

            for (int i = 0; i < maxEnemiesCountToSpawn; i++)
            {
                try
                {
                    if (i < maxEnemiesCountToSpawn)                    
                        SpawnAnEnemy(availableEnemiesList[1]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Debug.LogError("ArgumentOutOfRangeException " + 1 + " maxEnemiesCountToSpawn "+ maxEnemiesCountToSpawn+ " availableEnemiesList.Count "+ availableEnemiesList.Count);
                }
            }
            RemoveSpawnedFromAvailableEnemiesList();
        }
    }

    void RemoveSpawnedFromAvailableEnemiesList()
    {
        for (int i = 0; i < deployedEnemiesList.Count; i++)
        {
            if (availableEnemiesList.Contains(deployedEnemiesList[i]))
                availableEnemiesList.Remove(deployedEnemiesList[i]);
        }       
    }

    void SpawnAnEnemy(GameObject enemy)
    {
        DeployEnemyAtSpawnPoint(enemy);
    }

    void DeployEnemyAtSpawnPoint(GameObject enemy)
    {       
        int spawnerIndex = UnityEngine.Random.Range(0, enemiesSpawnersList.Count);

        enemy.transform.position = enemiesSpawnersList[spawnerIndex].transform.position;
       
        if (!usedSpawnersList.Contains(enemiesSpawnersList[spawnerIndex]))        
            usedSpawnersList.Add(enemiesSpawnersList[spawnerIndex]);

        if (!deployedEnemiesList.Contains(enemy))
            deployedEnemiesList.Add(enemy);

        enemiesSpawnersList[spawnerIndex].SetActive(true);

        enemiesSpawnersList.Remove(enemiesSpawnersList[spawnerIndex]);

        enemy.SetActive(true);
    }

    public void ReturnSpawnerAsAvailable(GameObject spawner)
    {
        spawner.SetActive(false);
        usedSpawnersList.Remove(spawner);
        enemiesSpawnersList.Add(spawner);
    }

    public void ReturnEnemyAsAvailable(GameObject enemy)
    {
        enemy.SetActive(false);
        deployedEnemiesList.Remove(enemy);
        availableEnemiesList.Add(enemy);
    }
}


