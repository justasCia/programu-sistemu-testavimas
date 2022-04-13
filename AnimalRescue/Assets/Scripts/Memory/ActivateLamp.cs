using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateLamp : MonoBehaviour
{
    public int lampId = 0;
    public LampRoomMng mngr;
    public GameObject lamp;
    public Material OnMat;
    public Material OffMat;
    public float timeOnOff = 1f;
    public UnityEvent UpdateComb;


    // Start is called before the first frame update
    void Start()
    {
        lamp.GetComponent<MeshRenderer>().material = OffMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        
        StartCoroutine(TurnOnNOff(timeOnOff));
    }

    public IEnumerator TurnOnNOff(float time)
    {
        lamp.GetComponent<MeshRenderer>().material = OnMat;
        UpdateComb.Invoke();
        //mngr.UpdateCombination(lampId);
        yield return new WaitForSeconds(time);
        lamp.GetComponent<MeshRenderer>().material = OffMat;
    }
}
