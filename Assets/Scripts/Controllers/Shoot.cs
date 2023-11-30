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

    public void DoShoot()
    {
        GameObject Projectile = GameObject.Instantiate(ProjectilePrefab);
        Projectile.transform.position = ProjectileStartPoint.transform.position;
        Projectile.SetActive(true);
    }
}
