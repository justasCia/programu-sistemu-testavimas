using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObj : MonoBehaviour
{
    Animator anim;
    public UnityEvent pressed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Pressed()
    {
        anim.SetBool("Interacted", true);
        pressed.Invoke();
    }
}
