using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    Collider2D col2d;

    [SerializeField]
    float projectileSpeed = 10f;

    [SerializeField]
    float selfDestroyDelay = 3f;

    private void OnEnable()
    {
        Invoke("DestroySelf", selfDestroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

 /*   private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision != null)
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

            if (enemy != null)
            {
                ImpactEnemy(enemy);
                DestroySelf();
            }
        }
    }*/

    void ImpactEnemy(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
    }


    void DestroySelf()
    {
        CancelInvoke("DestroySelf");
        Destroy(gameObject);
    }
}
