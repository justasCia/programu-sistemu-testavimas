using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    //Transform animal = null;

    private void Start() 
    {
        gameObject.GetComponent<WallClimbing>().enabled = false;
    }

    private void Update()
    {
        //animal = gameObject.GetComponent<interacting>().animal;

        

    }

    public void GetPower(string animal)
    {
        switch (animal)
        {
            case "Dog":
                gameObject.GetComponent<PlayerMovement>().speed = 10f;
                break;
            case "Cat":
                gameObject.GetComponent<WallClimbing>().enabled = true;
                break;
            case "Rat":
                //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.25f, 0.25f, 0.25f), 0.1f);
                transform.localScale =  new Vector3(0.25f, 0.25f, 0.25f);
                break;
        }
    }

    public void LosePower()
    {
        gameObject.GetComponent<PlayerMovement>().speed = 6f;
        gameObject.GetComponent<WallClimbing>().enabled = false;
        //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
