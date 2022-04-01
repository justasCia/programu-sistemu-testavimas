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
    //public TextMeshProUGUI label;

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

    private void Start()
    {
        cntrlr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, animalMask))
        {
            cursor.sprite = interactionCur.image;
            cursor.rectTransform.localScale = interactionCur.scale;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (equiped)
                {
                    Switch();
                }
                else
                {
                    PickUp();
                }
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
        }

        if (Input.GetKeyDown(KeyCode.Q) && equiped)
        {
            Drop();
        }
        //if (animal != null && equiped)
        //{
        //    animal.position = Vector3.Lerp(animal.position, holdPoint.position, lerpValue);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * range));
    }

    void PickUp()
    {
        animal = hit.transform;
        //label.text = animal.tag;

        animal.SetParent(holdPoint);
        animal.localPosition = Vector3.zero;
        animal.localRotation = Quaternion.Euler(Vector3.zero);
        animal.transform.Find("Armature").gameObject.SetActive(false);

        animal.GetComponent<Rigidbody>().freezeRotation = true;
        animal.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        animal.Find("HoldPoint").position = holdPoint.position;
        Debug.Log("Picked up " + hit.transform.name);
        equiped = true;
    }

    void Switch()
    {
        Drop();
        PickUp();
    }

    void Drop()
    {
        //label.text = "";
        animal.SetParent(null);
        animal.transform.Find("Armature").gameObject.SetActive(true);
        animal.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        animal.GetComponent<FixedJoint>().connectedBody = animal.Find("Armature").Find("Root").GetComponent<Rigidbody>();
        animal.GetComponent<Rigidbody>().freezeRotation = false;

        animal.GetComponent<Rigidbody>().velocity = cntrlr.velocity;

        animal.GetComponent<Rigidbody>().AddForce(holdPoint.forward * throwForce.x, ForceMode.Impulse);
        animal.GetComponent<Rigidbody>().AddForce(holdPoint.up * throwForce.y, ForceMode.Impulse);
        Debug.Log("Dropped ");
        //animal.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        animal = null;
        equiped = false;
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log(hit.transform.name);
        onInteract = hit.transform.GetComponent<Interactable>().onInteract;
        onInteract.Invoke();
    }
}