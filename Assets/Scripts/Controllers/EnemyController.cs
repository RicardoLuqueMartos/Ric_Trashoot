using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    GameObject player;

    [SerializeField]
    EnemyPool enemyPool;

    [SerializeField]
    float moveSpeed = 5f;
      
    [SerializeField]
    Rigidbody2D rigB2d;
    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(Rigidbody2D rb2D, GameObject _player)
    {
        rigB2d = rb2D;
        player = _player;

        player.transform.position = new Vector3(-2, -2, player.transform.position.z);

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
        playerController.AddToScore();
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

#if UNITY_EDITOR
    public void TestAimPlayer()
    {
        AimPlayer();
    }
#endif

    void AimPlayer()
    {     
        Vector2 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

#if UNITY_EDITOR
    public void TestMoveToPlayerPosition()
    {
        MoveToPlayerPosition();
    }
#endif

    void MoveToPlayerPosition()
    {
        rigB2d.velocity = rigB2d.transform.up * (1 * moveSpeed);
    }
}
