using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupView : MonoBehaviour
{

    public delegate void ItemPickup();
    public static event ItemPickup OnItemPickup;

    public delegate void ItemDrop();
    public static event ItemDrop OnItemDrop;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (ScenarioData.playerHeldItem == null)
            {
                OnItemPickup();
            }
            else
            {
                OnItemDrop();
            }

        }
    }

}
