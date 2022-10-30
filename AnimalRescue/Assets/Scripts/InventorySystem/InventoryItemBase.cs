using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        //losePower.Invoke();
        GameObject.FindWithTag("Player").GetComponent<PowerManager>().LosePower();

        transform.gameObject.SetActive(true);
        //transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.Find("Armature").gameObject.SetActive(false);

        transform.GetComponent<Rigidbody>().freezeRotation = true;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        transform.position = holdPoint.position;
        transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("HandHeld");

        //getPower.Invoke();
        GameObject.FindWithTag("Player").GetComponent<PowerManager>().GetPower(transform.tag);
    }

    public virtual void OnDrop()
    {
        //losePower.Invoke();
        GameObject.FindWithTag("Player").GetComponent<PowerManager>().LosePower();
        transform.SetParent(null);
        transform.Find("Armature").gameObject.SetActive(true);
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        transform.GetComponent<FixedJoint>().connectedBody = transform.Find("Armature").Find("Root").GetComponent<Rigidbody>();
        transform.GetComponent<Rigidbody>().freezeRotation = false;

        transform.GetComponent<Rigidbody>().velocity = cntrlr.velocity;

        transform.GetComponent<Rigidbody>().AddForce(holdPoint.forward * throwForce.x, ForceMode.Impulse);
        transform.GetComponent<Rigidbody>().AddForce(holdPoint.up * throwForce.y, ForceMode.Impulse);

        transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Animal body parts");

        interacting.animal = null;
        interacting.equiped = false;
    }

    public virtual void OnPickup()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        transform.SetParent(inventory.transform);
        transform.position = inventory.transform.position;
        //transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(ABC());
        //gameObject.SetActive(false);
    }

    IEnumerator ABC()
    {
        transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        //returning 0 will make it wait 1 frame
        yield return new WaitForSeconds(0.1f);
        //code goes here
        transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        gameObject.SetActive(false);
    }

    [Header("Throwing")]
    public Vector2 throwForce = new Vector2(5f, 5f);

    public CharacterController cntrlr;
    public bool UseItemAfterPickup = true;
    public interacting interacting;

    public UnityEvent getPower;
    public UnityEvent losePower;
}
