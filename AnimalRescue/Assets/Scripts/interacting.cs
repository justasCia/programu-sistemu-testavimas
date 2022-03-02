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

        if (animal != null && equiped)
        {
            animal.position = holdPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * range));
    }

    void PickUp()
    {
        animal = hit.transform;
        animal.position = holdPoint.position;
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
        Debug.Log("Dropped ");
        animal.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        animal = null;
        equiped = false;
    }
}