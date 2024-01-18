using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 30;
    private float horizontalinput;
    private float leftbound = -15;
    private float rightbound = 15;
    private Vector3 Playerpos;
    private Rigidbody playerrb;
    private float gravitymodifier = 3;
    private float jumpforce = 21;
    public bool GameOver = false;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        //to get game object rigid body
        playerrb = GetComponent<Rigidbody>();
        Physics.gravity *= gravitymodifier;
    }

    // Update is called once per frame
    void Update()
    {
        //to get input
        horizontalinput = Input.GetAxis("Horizontal");
        //to move player left right
        transform.Translate(Vector3.right * speed * horizontalinput * Time.deltaTime);
        //to jump player
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !GameOver)
        {
            playerrb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            onGround = false;
        }
        //to stop player from going out of bound
        if (transform.position.x > rightbound)
        {
            Playerpos = transform.position;
            Playerpos.x = rightbound;
            transform.position = Playerpos;
        }
        else if (transform.position.x < leftbound)
        {
            Playerpos = transform.position;
            Playerpos.x = leftbound;
            transform.position = Playerpos;
        }
    }

    //to destroy object which collide with player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameOver = true;
            Debug.Log("GameOver");
        }
        if (collision.gameObject.CompareTag("powerup"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}
