using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    //Transform animal = null;
    public float ratScale = .25f;

    public Image powerUpHolder;
    public Sprite empty;
    public Sprite speedUp;
    public Sprite sizeDown;
    public Sprite wallClimb;

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
        Debug.Log(animal);
        switch (animal)
        {
            case "Dog":
                gameObject.GetComponent<PlayerMovement>().speed = 10f;
                ChangeImage(speedUp);
                break;
            case "Cat":
                gameObject.GetComponent<WallClimbing>().enabled = true;
                ChangeImage(wallClimb);
                break;
            case "Rat":
                //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.25f, 0.25f, 0.25f), 0.1f);
                transform.localScale =  new Vector3(ratScale, ratScale, ratScale);
                ChangeImage(sizeDown);
                break;
        }
    }

    public void LosePower()
    {
        gameObject.GetComponent<PlayerMovement>().speed = 6f;
        gameObject.GetComponent<WallClimbing>().enabled = false;
        //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        ChangeImage(empty);
    }

    void ChangeImage(Sprite img)
    {
        powerUpHolder.sprite = img;
    }
}
