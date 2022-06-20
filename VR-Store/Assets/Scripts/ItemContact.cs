using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContact : MonoBehaviour
{

    public delegate void ItemTrigger(Collider collider);
    public static event ItemTrigger OnItemTrigger;

    private void OnTriggerEnter(Collider other)
    {
        OnItemTrigger(other);
    }
}
