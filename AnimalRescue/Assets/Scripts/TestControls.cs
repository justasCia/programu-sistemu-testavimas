using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour
{
    public CharacterController cntrl;
    public float speed = 2f;
    public float rotationSpeed = 10f;

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right *Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical") * transform.forward;
        cntrl.Move(move * Time.deltaTime * speed);

        
        

        Vector3 camInput = new Vector3(0,(Input.GetKey(KeyCode.J) ? -1 : 0) + (Input.GetKey(KeyCode.L) ? 1 : 0),0);
        //transform.forward = transform.forward + (camInput * rotationSpeed * Time.deltaTime);
        transform.Rotate(camInput * rotationSpeed * Time.deltaTime);
        
    }
}
