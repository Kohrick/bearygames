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

    //distance btwn flowers
    private GameObject[] multipleObjects;
    public Transform closestObject;
    public bool objectContact;


    public flowerBehaviour flowerBehaviour;
    public bearInventory bearInventory;


    void Start()
    {
        bearInventory = GameObject.FindGameObjectWithTag("bear").GetComponent<bearInventory>();
        closestObject = null;
        objectContact = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flowerBehaviour.canGetPicked && flowerBehaviour.readyToPick)
            {
                
                flowerBehaviour.health--;
                
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            destroyFlower = false;
        }

        closestObject = getClosestObject();
        
    }

    //---------------------------------------------------------------------------
    private void OnTriggerStay2D(Collider2D collision)
    {
        flowerBehaviour = closestObject.gameObject.GetComponent<flowerBehaviour>();
        GameObject other = collision.gameObject;
        if (other.CompareTag("pickableItem"))
        {
            flowerBehaviour = other.GetComponent<flowerBehaviour>();
        }
    }

    //-------------------------------------------------------------------------------
    public Transform getClosestObject()
    {
        multipleObjects = GameObject.FindGameObjectsWithTag("pickableItem");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleObjects)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans; 
    }
}
