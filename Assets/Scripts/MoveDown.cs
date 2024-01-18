using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float downspeed = 30;
    private float zbound = -20;
    private PlayerControl playerscript;
    // Start is called before the first frame update
    void Start()
    {
        //to get PlayerControl Script
        playerscript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //to move obstacle
        if (!playerscript.GameOver)
        {
            transform.Translate(Vector3.back * downspeed * Time.deltaTime);
        }
        //to despawn obstacle
        if (transform.position.z < zbound)
        {
            Destroy(gameObject);
        }
    }
}
