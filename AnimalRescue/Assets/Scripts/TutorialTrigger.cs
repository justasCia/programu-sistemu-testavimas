using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public UnityEvent OnEnter;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            OnEnter.Invoke();
            triggered = true;
        }
    }
}
