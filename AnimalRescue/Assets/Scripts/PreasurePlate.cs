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

    public List<Collider> ObjOnPlate = new List<Collider>();

    public AudioSource plateSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (LayerMask.NameToLayer("Player") == other.gameObject.layer ||
            LayerMask.NameToLayer("Animal") == other.gameObject.layer)

        {
            //Debug.Log("pressed");
            ObjOnPlate.Add(other);
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (LayerMask.NameToLayer("Player") == other.gameObject.layer ||
            LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            ObjOnPlate.Remove(other);
            if (ObjOnPlate.Count <= 0)
                Disactivate();
        }
    }

    void Activate()
    {
        isPressed = true;
        anim.SetBool("Pressed", isPressed);
        pressed.Invoke();
        plateSound.Play();
    }
    
    void Disactivate()
    {
        isPressed = false;
        anim.SetBool("Pressed", isPressed);
        unpressed.Invoke();

    }
}
