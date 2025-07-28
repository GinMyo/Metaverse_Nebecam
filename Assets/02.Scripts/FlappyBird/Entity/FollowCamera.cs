using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    float offsetX;

    void Start()
    {
        if (player == null)
            return;

        offsetX = transform.position.x - player.position.x;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;
        Vector3 targetPos = new Vector3(player.position.x + offsetX, 0, this.transform.position.z);
        transform.position = targetPos;
    }    
}
