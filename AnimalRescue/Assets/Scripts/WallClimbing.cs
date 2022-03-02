using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    [SerializeField]
    private Transform controller;
    public bool climbing = false;
    [SerializeField]
    private float speed = 10f;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (climbing && Input.GetKey("w"))
        {
            controller.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (climbing && Input.GetKey("s"))
        {
            controller.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "climbable")
        {
            playerMovement.enabled = false;
            climbing = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "climbable")
        {
            playerMovement.enabled = true;
            climbing = false;
        }
    }
}
