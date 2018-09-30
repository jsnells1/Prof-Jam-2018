using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float songTime = 10f;
    bool isSongPlaying;

    void Start()
    {
        isSongPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSongPlaying)
            transform.Translate(Vector3.forward * Time.deltaTime * 7f);
        else 
        {
            songTime -= Time.deltaTime;
            if (songTime <= 0f)
                Destroy(gameObject);
        }
    }

    public void Countdown()
    {
        isSongPlaying = true;
    }
}
