using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
        {
            ProjectileController projectile = col.gameObject.GetComponent<ProjectileController>();

            if (projectile != null)
            {
                ImpactProjectile(projectile);
                DestroySelf();
            }
            else
            {
                PlayerController player = col.gameObject.GetComponent<PlayerController>();
               
                if (player != null) ImpactPlayer(player);
            }
        }
    }

    void ImpactProjectile(ProjectileController projectile)
    {
        Destroy(projectile.gameObject);
    }

    void ImpactPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
    }


    void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
