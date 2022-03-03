using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacting : MonoBehaviour
{
    RaycastHit hit;
    public Transform animal = null;
    public Camera cam;
    public float range = 1f;
    public LayerMask mask;
    public Transform holdPoint;
    public float lerpValue = 1f;

    public bool equiped = false;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, mask))
        {
            //if (animal != null)
                 

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log(hit.transform.name);

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
        animal.SetParent(null);
        animal.transform.Find("Armature").gameObject.SetActive(true);
        animal.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        animal.GetComponent<FixedJoint>().connectedBody = animal.Find("Armature").Find("Root").GetComponent<Rigidbody>();
        animal.GetComponent<Rigidbody>().freezeRotation = false;
        Debug.Log("Dropped ");
        //animal.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        animal = null;
        equiped = false;
    }
}