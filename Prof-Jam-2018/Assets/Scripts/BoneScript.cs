using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour
{
    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        xPos = transform.position.x;
    }

    private void OnCollisionExit(Collision collision)
    {
        Vector3 positionVec = transform.position;

        positionVec.x = xPos;

        //transform.position = positionVec;
    }
}
