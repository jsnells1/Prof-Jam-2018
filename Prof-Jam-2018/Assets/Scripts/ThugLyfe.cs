using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThugLyfe : MonoBehaviour
{
    bool hasAlreadyCollided;
    public List<SpriteRenderer> glassesParts;
    public AudioSource sound;
    public EnemyMovement em;

    void Start()
    {
        hasAlreadyCollided = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasAlreadyCollided && collision.gameObject.tag == "Player")
        {
            hasAlreadyCollided = true;
            Debug.Log("Collided with player");
            YoHoYoHoThugishLyfesForMe();
        }
            
    }

    void YoHoYoHoThugishLyfesForMe()
    {
        foreach(SpriteRenderer sr in glassesParts)
        {
            sr.enabled = true;
        }
        sound.enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        em.Countdown();
    }
}