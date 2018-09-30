using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenPlayerMovement : MonoBehaviour
{
    Vector3 lastPosition;
    float movementBarrier;

    void Start()
    {
        movementBarrier = 0.1f;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xSpeed, zSpeed;

        xSpeed = (Mathf.Abs(transform.position.x - lastPosition.x) < movementBarrier) ? lastPosition.x : transform.position.x;
        zSpeed = (Mathf.Abs(transform.position.z - lastPosition.z) < movementBarrier) ? lastPosition.z : transform.position.z;

        transform.position = new Vector3(xSpeed, transform.position.y, transform.position.z);


        lastPosition = transform.position;
    }
}
