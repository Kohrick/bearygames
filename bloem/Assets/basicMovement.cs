using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float playerSpeed;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(-playerSpeed, playerRB.velocity.y);
        }
        if(Input.GetKeyUp(KeyCode.A)) {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
    }
}
