using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject player;
       
    private void Awake()
    {
        if (gm == null)
            gm = this;
        else
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform floor = GameObject.Find("Floor").transform;

        Vector3 playerPosition = new Vector3(-118.5f, floor.position.y + 1f, 0);

        Instantiate(player, playerPosition, Quaternion.Euler(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

}
