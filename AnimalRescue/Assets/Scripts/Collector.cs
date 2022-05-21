using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public GameObject player;
    public int animalCountLvl = 3;
    public int currentCount = 0;

    public UnityEvent OnCompleted;
    public GameObject completedMenu;
    //public int LoadScene = 0;

    public float defaultTimer = 2f;
    public float timer;
    bool collected = false;
    bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        timer = defaultTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected && !completed)
        {
            if (timer > 0) 
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("all collected");
                completed = true;
                OnCompleted.Invoke();
                StartCoroutine(Completed(2f));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            currentCount++;
            if (currentCount >= animalCountLvl)
            {
                collected = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (LayerMask.NameToLayer("Animal") == other.gameObject.layer)
        {
            currentCount--;
            timer = defaultTimer;
            collected = false;
        }
    }

    IEnumerator Completed(float sec)
    {
        WaitForSeconds wait = new WaitForSeconds(sec);
        yield return wait;
        completedMenu.SetActive(true);
        DisablePlayer();
    }

    public void DisablePlayer()
    {
        //player.GetComponent<CameraMovement>().enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
}
