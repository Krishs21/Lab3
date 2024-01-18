using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] items;
    private Vector3 Spawnpos;
    private float zpos, ypos;
    private int xpos;
    private int id;
    private float time;
    private PlayerControl playerscript;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time + 2;
        //to get the PlayerControl Script
        playerscript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //to spawn at random time
        if (time <= Time.time && !playerscript.GameOver)
        {
            SpawnManage();
            time += Random.Range(1, 3);
        }
    }
    //Spawn the enemy or powerup
    void SpawnManage()
    {
        id = Random.Range(0, 4);
        ypos = items[id].transform.position.y;
        zpos = 60;
        xpos = Random.Range(-15, 16);
        Spawnpos = new Vector3(xpos, ypos, zpos);
        Instantiate(items[id], Spawnpos, items[id].transform.rotation);
    }
}
