using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class interacting : MonoBehaviour
{
    [Serializable] 
    private class CursorData
    {
        public Sprite image;
        public Vector3 scale;
    }

    [Header("Technical")]
    public Camera cam;
    public float range = 1f;
    public Transform holdPoint;
    public bool equiped = false;
    public float lerpValue = 1f;
    public UnityEvent getPower;
    public UnityEvent losePower;
   
    private InventoryItemBase mCurrentItem = null;
    public InteractableItemBase mInteractItem = null;
    public Hotbar Hotbar;
    public Inventory Inventory;
    public TextMeshProUGUI label;

    [Header("Animal")]
    public Transform animal = null;
    public LayerMask animalMask;

    [Header("Throwing")]
    public Vector2 throwForce = new Vector2(5f, 5f);

    [Header("Interactable objects")]
    UnityEvent onInteract;
    public LayerMask interMask;

    [Header("Cursor")]
    public Image cursor;
    [SerializeField] CursorData defaultCur; 
    [SerializeField] CursorData interactionCur;

    RaycastHit hit;
    CharacterController cntrlr;

    //labors
    //public GameObject doggo;
    //public float speed = 100f;
    //bool isMoving = false;
    //Vector3 poss = new Vector3();

    private void Start()
    {
        cntrlr = GetComponent<CharacterController>();
        Inventory.ItemUsed += Inventory_ItemUsed;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, animalMask))
        {
            cursor.sprite = interactionCur.image;
            cursor.rectTransform.localScale = interactionCur.scale;
            TryInteraction(hit.transform);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, interMask))
        {
            cursor.sprite = interactionCur.image;
            cursor.rectTransform.localScale = interactionCur.scale;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(hit);
            }
        }
        else
        {
            cursor.sprite = defaultCur.image;
            cursor.rectTransform.localScale = defaultCur.scale;
            Hotbar.CloseMessagePanel();
        }

        if (mCurrentItem != null && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
        //if (animal != null && equiped)
        //{
        //    animal.position = Vector3.Lerp(animal.position, holdPoint.position, lerpValue);
        //}


        //laboro stuff
        
    }

    void Lab2(Vector3 poss, float speed, bool isMoving, GameObject doggo)
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range+5))
        {
            if (Input.GetMouseButtonDown(0))
            {
                poss = hit.point;
                Debug.Log(poss);
                isMoving = true;
                
                doggo.transform.LookAt(poss);
            }
        }
        if (isMoving && poss != Vector3.zero)
        {
            //doggo.GetComponent<Rigidbody>().MovePosition(poss * Time.deltaTime * speed);
            doggo.transform.position = Vector3.MoveTowards(doggo.transform.position, poss, speed);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * range));
    }

    void PickUp()
    {
        //animal = hit.transform;
        //label.text = animal.tag;

        //animal.SetParent(holdPoint);
        //animal.localPosition = Vector3.zero;
        //animal.localRotation = Quaternion.Euler(Vector3.zero);
        //animal.transform.Find("Armature").gameObject.SetActive(false);

        //animal.GetComponent<Rigidbody>().freezeRotation = true;
        //animal.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //animal.position = holdPoint.position;
        //Debug.Log("Picked up " + hit.transform.name);
        //getPower.Invoke();
        //GetComponent<PowerManager>().GetPower(animal.name);
        //equiped = true;

        //animal.Find("HoldPoint").position = holdPoint.position;
        //Debug.Log("Picked up " + hit.transform.name);
        //equiped = true;

        InteractWithItem();
    }

    //void Switch()
    //{
    //    Drop();
    //    PickUp();
    //}

    void Drop()
    {
        //label.text = "";
        //losePower.Invoke();
        GetComponent<PowerManager>().LosePower();
        //animal.SetParent(null);
        //animal.transform.Find("Armature").gameObject.SetActive(true);
        //animal.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        //animal.GetComponent<FixedJoint>().connectedBody = animal.Find("Armature").Find("Root").GetComponent<Rigidbody>();
        //animal.GetComponent<Rigidbody>().freezeRotation = false;

        //animal.GetComponent<Rigidbody>().velocity = cntrlr.velocity;

        //animal.GetComponent<Rigidbody>().AddForce(holdPoint.forward * throwForce.x, ForceMode.Impulse);
        //animal.GetComponent<Rigidbody>().AddForce(holdPoint.up * throwForce.y, ForceMode.Impulse);
        //Debug.Log("Dropped ");
        //animal.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //animal = null;
        //equiped = false;
        Inventory.RemoveItem(mCurrentItem);
        
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log(hit.transform.name);
        onInteract = hit.transform.GetComponent<Interactable>().onInteract;
        onInteract.Invoke();
    }

    private void TryInteraction(Transform other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();

        if (item != null)
        {
            if (item.CanInteract())
            {
                mInteractItem = item;
                Hotbar.OpenMessagePanel(mInteractItem);
            }
        }
    }
    public void InteractWithItem()
    {
        if (mInteractItem != null)
        {
            mInteractItem.OnInteract();

            if (mInteractItem is InventoryItemBase)
            {
                InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
                Inventory.AddItem(inventoryItem);
                inventoryItem.OnPickup();

                if (inventoryItem.UseItemAfterPickup)
                {
                    Inventory.UseItem(inventoryItem);
                }
                Hotbar.CloseMessagePanel();
                mInteractItem = null;
            }
        }
    }

    private void SetItemActive(InventoryItemBase item, bool active)
    {
        GameObject currentItem = (item as MonoBehaviour).gameObject;
        currentItem.SetActive(active);
        currentItem.transform.parent = active ? holdPoint.transform : null;
    }
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        // If the player carries an item, un-use it (remove from player's hand)
        if (mCurrentItem != null)
        {
            SetItemActive(mCurrentItem, false);
        }

        InventoryItemBase item = e.Item;

        // Use item (put it to hand of the player)
        SetItemActive(item, true);

        mCurrentItem = e.Item;
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        InventoryItemBase item = e.Item;
        //Debug.Log(item.name + "");
        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;
        //Debug.Log("Inventory_ItemRemoved metodas:" + goItem.name);
        if (item == mCurrentItem)
        {
            mCurrentItem = null;
            item.OnDrop();
        }
            
        

    }
}