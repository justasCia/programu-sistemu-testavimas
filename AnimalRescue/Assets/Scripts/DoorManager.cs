using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool IsOpen = false;
    Animator anim;
    public AudioSource doorsound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsOpen", IsOpen);
    }

    public void OpenDoor()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            anim.SetBool("IsOpen", IsOpen);
            doorsound.Play();
        }
    }

    public void CloseDoor()
    {
        if (IsOpen)
        {
            IsOpen = false;
            anim.SetBool("IsOpen", IsOpen);
        }
    }
}
