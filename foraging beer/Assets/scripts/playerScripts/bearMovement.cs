using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed;
    private Vector2 forceToApply;
    public float forceDamping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        rb.velocity = moveForce;
    }
}
