using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -25);
    public float camSpeed = 1;

    private void LateUpdate()
    {
        Vector3 desiredPosition =  player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
