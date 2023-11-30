using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour, IShoot
{
    [SerializeField]
    GameObject ProjectilePrefab;

    [SerializeField]
    GameObject ProjectileStartPoint;

    [SerializeField]
    GameObject ProjectileTargetPoint;

    public void DoShoot()
    {
        GameObject Projectile = GameObject.Instantiate(ProjectilePrefab);
        Projectile.transform.position = ProjectileStartPoint.transform.position;
        Projectile.transform.rotation = ProjectileStartPoint.transform.rotation;
        Projectile.GetComponent<ProjectileController>().spawnPoint = ProjectileStartPoint;
        Projectile.SetActive(true);
    }
}
