using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Collider2D col2d;

    [SerializeField]
    Rigidbody2D rigB2d;

    [SerializeField]
    float projectileSpeed = 10f;

    [SerializeField]
    float selfDestroyDelay = 3f;

    public GameObject spawnPoint;
    #endregion Variables

    private void OnEnable()
    {
        Invoke("DestroySelf", selfDestroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        rigB2d.velocity = spawnPoint.transform.up * projectileSpeed;
    }

    void DestroySelf()
    {
        CancelInvoke("DestroySelf");
        Destroy(gameObject);
    }
}
