using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearInventory : MonoBehaviour
{

    public GameObject inventory;
    public int flower1;
    

    void Start()
    {
        inventory.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryToggle();
        }
      
    }

    void InventoryToggle()
    {
        if (!inventory.activeSelf)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
