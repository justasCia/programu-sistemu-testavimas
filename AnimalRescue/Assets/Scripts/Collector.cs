using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public int animalCountLvl = 3;
    public int currentCount = 0;

    public UnityEvent OnCompleted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            currentCount++;
            if (currentCount >= animalCountLvl)
            {
                StartCoroutine(Completed(2));
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            currentCount--;
        }
    }

    IEnumerator Completed(float sec)
    {
        WaitForSeconds wait = new WaitForSeconds(sec);
        yield return wait;
        Debug.Log("all collected");
        OnCompleted.Invoke();
    }
}
