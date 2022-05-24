using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Glove : MonoBehaviour
{
    public UnityEvent interacted;
    bool collected = false;

    public void Collect()
    {
        if (!collected)
        {
            interacted.Invoke();
            collected = true;
        }
    }
}
