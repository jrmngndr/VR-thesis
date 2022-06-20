using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupController : MonoBehaviour
{
    private void OnEnable()
    {
        ItemPickupView.OnItemPickup += PickUp;
        ItemPickupView.OnItemDrop += Drop;

    }

    private void OnDisable()
    {
        ItemPickupView.OnItemPickup -= PickUp;
        ItemPickupView.OnItemDrop -= Drop;

    }

    void Update()
    {
        if (ScenarioData.playerHeldItem != null)
        {
            MoveItem();
        }
    }

    private void PickUp()
    {
        RaycastHit raycast;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycast, ScenarioData.pickupRange))
        {
            Rigidbody rigidBody = raycast.transform.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                rigidBody.useGravity = false;
                rigidBody.drag = 10;
                rigidBody.transform.parent = ScenarioData.itemHolder;
                ScenarioData.playerHeldItem = raycast.transform.gameObject;
            }
        }        
    }

    //dislike
    void MoveItem()
    {
        if (Vector3.Distance(ScenarioData.itemHolder.position, ScenarioData.playerHeldItem.transform.position) > 0.1f)
        {
            Vector3 direction = ScenarioData.itemHolder.position - ScenarioData.playerHeldItem.transform.position;
            ScenarioData.playerHeldItem.GetComponent<Rigidbody>().AddForce(direction * 100f); //add rigidbody to data model?
            ScenarioData.playerHeldItem.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Drop()
    {
        Rigidbody rigidBody = ScenarioData.playerHeldItem.GetComponent<Rigidbody>();
        rigidBody.drag = 0;
        rigidBody.useGravity = true;
        rigidBody.freezeRotation = false;
        ScenarioData.playerHeldItem.transform.parent = null;
        ScenarioData.playerHeldItem = null;
    }
}
