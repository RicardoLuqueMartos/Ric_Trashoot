using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour, IShoot
{
    #region Variables
    [SerializeField]
    GameObject ProjectilePrefab;

    [SerializeField]
    GameObject ProjectileStartPoint;

    [SerializeField]
    GameObject ProjectileTargetPoint;
    #endregion Variables

    public void DoShoot()
    {
        GameObject Projectile = GameObject.Instantiate(ProjectilePrefab);
        Projectile.transform.position = ProjectileStartPoint.transform.position;
        Projectile.transform.rotation = ProjectileStartPoint.transform.rotation;
        Projectile.GetComponent<ProjectileController>().spawnPoint = ProjectileStartPoint;
        Projectile.SetActive(true);
    }
}
