using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    Transform animal = null;

    private void Start() 
    {
        gameObject.GetComponent<WallClimbing>().enabled = false;
    }

    private void Update()
    {
        animal = gameObject.GetComponent<interacting>().animal;

        if (animal != null)
            GetPower();
        else
            LosePower();

    }

    void GetPower()
    {
        switch (animal.name)
        {
            case "Dog":
                gameObject.GetComponent<PlayerMovement>().speed = 10f;
                break;
            case "Cat":
                gameObject.GetComponent<WallClimbing>().enabled = true;
                break;
        }
    }

    void LosePower()
    {
        gameObject.GetComponent<PlayerMovement>().speed = 6f;
        gameObject.GetComponent<WallClimbing>().enabled = false;
    }
}
