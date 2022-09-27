using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bearCollecting : MonoBehaviour
{
    [SerializeField]

    private bool canCollect;
    public bool isColllecting;
    public bool destroyFlower = false;
    public Collider2D bearCollider;
    public Vector3 closest;
    public Vector3 distance;

    public flowerBehaviour flowerBehaviour;
    public bearInventory bearInventory;


    void Start()
    {
        bearInventory = GameObject.FindGameObjectWithTag("bear").GetComponent<bearInventory>();

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flowerBehaviour.canGetPicked && flowerBehaviour.readyToPick && canCollect)
            {
                destroyFlower = true;
                bearInventory.flower1 += 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            destroyFlower = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canCollect = true;


        GameObject other = collision.gameObject;
        if (other.CompareTag("pickableItem"))
        {
            flowerBehaviour = other.GetComponent<flowerBehaviour>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickableItem"))
        {
                canCollect = false;
        }

    }

}
