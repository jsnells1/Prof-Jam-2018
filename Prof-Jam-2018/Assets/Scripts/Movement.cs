using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Move_Left"))
        {
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0f, 0f));
        }
        else if (Input.GetButton("Move_Right"))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
        }

        if(Input.GetButton("Move_Forward"))
        {
            transform.Translate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
        else if (Input.GetButton("Move_Backward"))
        {
            transform.Translate(new Vector3(0f, 0f, -1 * speed * Time.deltaTime));
        }
    }
}
