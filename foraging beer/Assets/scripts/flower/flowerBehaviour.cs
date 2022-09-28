using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerBehaviour : MonoBehaviour
{
    public float timeToGrow;
    public float fullyGrown;
    public bool readyToPick = false;
    public bool canGetPicked = false;
    public bearCollecting bearCollecting;
    public bearInventory bearInventory;
    public int health = 1;

    

    void Start()
    {
        health = 1;
        timeToGrow = 0;
        bearCollecting = GameObject.FindGameObjectWithTag("bear").GetComponent<bearCollecting>();
        bearInventory = GameObject.FindGameObjectWithTag("bear").GetComponent<bearInventory>();
    }


    void Update()
    {
//makes the plant 'grow'
        timeToGrow += Time.deltaTime;
        
        
// placeholder for the growing mechanic im going to make for the flowers
        if (fullyGrown <= timeToGrow)
        {
            readyToPick = true;
        }
        else
        {
            readyToPick = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

//checks to see if the player is choosing to pick this flower
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bear"))
        {
            canGetPicked = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bear"))
        {
            canGetPicked = false;
        }
    }



} 
