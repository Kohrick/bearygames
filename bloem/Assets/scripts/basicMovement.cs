using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;

    //variables voor lopen :D
    public float playerSpeed;
    private bool isPressedA;
    private bool isPressedD;
    private bool dissableA;
    private bool dissableD;

    //jump variables :|
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool jumping;
    public bool isOnGround;

    public Transform feetPosition;
    public float groundCheckRadius;
    public LayerMask groundLayermask;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //simpel lopen :D (links(a) en rechts(d)
        if(Input.GetKey(KeyCode.A))
        {
            if (!dissableA)
            {
                playerRB.velocity = new Vector2(-playerSpeed, playerRB.velocity.y);
                isPressedA = true;
                if (isPressedD)
                {
                    dissableD = true;
                }
            }


            dissableA = false;
            
        }

        if(Input.GetKeyUp(KeyCode.A)) {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            isPressedA = false;
        }

        if (Input.GetKey(KeyCode.D) )
        {
            if(!dissableD)
            {
                playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
                isPressedD = true;
                if (isPressedA)
                {
                    dissableA = true;
                }
            }


           
            dissableD = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            isPressedD= false;  
        }



        //springen 
        isOnGround = Physics2D.OverlapCircle(feetPosition.position, groundCheckRadius, groundLayermask);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jumpTimeCounter = jumpTime;
            jumping = true;
        }

        if (Input.GetKey(KeyCode.Space) && jumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumping= false;
            }
        }

        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(feetPosition.position, groundCheckRadius);
    }
}
