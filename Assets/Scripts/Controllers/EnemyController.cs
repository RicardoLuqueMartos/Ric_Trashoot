using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    [SerializeField]
    EnemyPool enemyPool;

    [SerializeField]
    float moveSpeed = 5f;
      
    [SerializeField]
    Rigidbody2D rigB2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            AimPlayer();

            MoveToPlayerPosition();
        }
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
        player.AddToScore();
        DestroySelf();
    }

    void ImpactPlayer(PlayerController player)
    {

        player.gameObject.SetActive(false);
        player.EndGame();
    }

    void DestroySelf()
    {
        enemyPool.ReturnEnemyAsAvailable(gameObject);
    }

   void AimPlayer()
    {     
        Vector2 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    void MoveToPlayerPosition()
    {
        rigB2d.velocity = rigB2d.transform.up * (1 * moveSpeed);
    }
}
