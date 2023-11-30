using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    EnemyPool pool;

    private void OnEnable()
    {
        Invoke("ReturnAsAvailableSpawner", 1);
    }

    void ReturnAsAvailableSpawner()
    {
        pool.ReturnSpawnerAsAvailable(gameObject);
    }
}
