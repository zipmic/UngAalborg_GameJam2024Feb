using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.5f;
    private Vector3 camPos;

    private void Start()
    {
        camPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            camPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, camPos, followSpeed);
        }
    }
}