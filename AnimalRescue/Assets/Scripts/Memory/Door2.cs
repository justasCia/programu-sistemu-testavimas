using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Animator open;
    
    public void DoorOpen()
    {
        open.SetTrigger("open");
    }
}
