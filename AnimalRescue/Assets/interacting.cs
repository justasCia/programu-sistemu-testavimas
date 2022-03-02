using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacting : MonoBehaviour
{
    RaycastHit hit;
    public Camera cam;
    public float range = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (Input.GetMouseButtonDown(0))
                Debug.Log(hit.transform.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * range));
    }
}
