using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemBase : MonoBehaviour
{
    public string Name;
    public Sprite Image;
    public string InteractText = "Press E to pickup the item";
    public Transform holdPoint;


    public virtual void OnInteract()
    {
    }

    public virtual bool CanInteract()
    {
        return true;
    }
}

public class InventoryItemBase : InteractableItemBase
{
    public InventorySlot Slot
    {
        get; set;
    }

    public virtual void OnUse()
    {
        transform.gameObject.SetActive(true);
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.Find("Armature").gameObject.SetActive(false);

        transform.GetComponent<Rigidbody>().freezeRotation = true;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        transform.position = holdPoint.position;
    }

    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
            gameObject.transform.eulerAngles = DropRotation;
        }
    }

    public virtual void OnPickup()
    {
        //Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);

    }

    public Vector3 DropRotation;

    public bool UseItemAfterPickup = true;


}
