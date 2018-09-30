using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawns;
    float maxTime = 15f;
    float minTime = 5f;
    float currentTime;
    public Object enemy;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(Random.Range(0, 2));
        currentTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0)
        {
            currentTime = Random.Range(minTime, maxTime);
            Spawn(Random.Range(0, 2));
        }

        currentTime -= Time.deltaTime;
    }

    void Spawn(int spawnerNumber)
    {
        Instantiate(enemy, spawns[spawnerNumber]);
    }
}
