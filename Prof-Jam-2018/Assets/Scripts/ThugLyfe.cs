using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThugLyfe : MonoBehaviour
{
    bool isMoving;
    public float moveSpeed;
    float lerpPosition = 0;
    Vector3 initialPosition;
    public List<SpriteRenderer> glassesParts;
    public Transform glasses;
    public Transform glassesFacePosition;

    private void Update()
    {
        //if (glasses.Translate(Mathf.Lerp(initialPosition.y, 0f, Time.deltaTime * moveSpeed));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            YoHoYoHoThugishLyfesForMe();
    }

    void YoHoYoHoThugishLyfesForMe()
    {
        foreach(SpriteRenderer sr in glassesParts)
        {
            sr.enabled = true;
        }

        isMoving = true;
        initialPosition = glasses.position;
    }
}
