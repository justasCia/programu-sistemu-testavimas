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
        //Debug.Log(other.gameObject.layer);
        if (LayerMask.NameToLayer("Player") == other.gameObject.layer ||
            LayerMask.NameToLayer("Animal") == other.gameObject.layer)

        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (LayerMask.NameToLayer("Player") == other.gameObject.layer ||
            LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            Disactivate();
        }
    }

    void Activate()
    {
        isPressed = true;
        anim.SetBool("Pressed", isPressed);
        pressed.Invoke();
    }
    
    void Disactivate()
    {
        isPressed = false;
        anim.SetBool("Pressed", isPressed);
        unpressed.Invoke();

    }
}
