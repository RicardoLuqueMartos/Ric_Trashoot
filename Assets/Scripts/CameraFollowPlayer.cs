using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject player;
    #endregion Variables

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3( player.transform.position.x, player.transform.position.y, transform.position.z), Time.deltaTime);
    }
}
