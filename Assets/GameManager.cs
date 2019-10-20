using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject toSpawn;
    public float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnArrow", 2.0f, spawnInterval);

        //Instantiate(toSpawn, new Vector3(0, 4, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnArrow()
    {
        Instantiate(toSpawn, new Vector3(-100, 144, 200), Quaternion.AngleAxis(90, Vector3.up));
    }
}