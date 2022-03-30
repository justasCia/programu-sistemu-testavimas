using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PreasurePlate : MonoBehaviour
{
    public Animator anim;

    public UnityEvent pressed; 
    public UnityEvent unpressed;

    public bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null || other.GetComponent<CharacterController>() != null)
        {
            isPressed = true;
            anim.SetBool("Pressed", isPressed);
            pressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            isPressed = false;
            anim.SetBool("Pressed", isPressed);
            unpressed.Invoke();
        }
    }
}
