using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObj : MonoBehaviour
{
    public bool bumpable = false;
    public bool pressable = true;
    bool isPressed = false;
    Animator anim;
    public UnityEvent pressed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Bumpable", bumpable);
    }

    public void Pressed()
    {
        if (!isPressed && pressable)
        {
            isPressed = true;
            anim.SetTrigger("Interacted");
            pressed.Invoke();
            if (bumpable)
            {
                Unpress();
            }
        }
    }

    public void Unpress()
    {
        isPressed = false;
        anim.SetTrigger("Interacted");
    }
}
