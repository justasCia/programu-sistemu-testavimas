using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalCount : MonoBehaviour
{
    public int dogCount = 0;
    public int catCount = 0;
    public int ratCount = 0;

    public TextMeshProUGUI dogText;
    public TextMeshProUGUI catText;
    public TextMeshProUGUI ratText;
    // Start is called before the first frame update
    void Start()
    {
        dogText.text = 0 + " / " + dogCount.ToString();
        catText.text = 0 + " / " + catCount.ToString();
        ratText.text = 0 + " / " + ratCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount(InventoryItemBase item)
    {
        string animal = item.Name;
        Debug.Log(animal);
        switch (animal)
        {
            case "Dog":
                if (item.Slot.Count == dogCount)
                {
                    dogText.color = new Color(0, 100, 0);
                }
                else { dogText.color = new Color(255, 0, 0); }
                dogText.text = item.Slot.Count.ToString() + " / " + dogCount.ToString();
                break;
            case "Cat":
                if (item.Slot.Count == catCount)
                {
                    catText.color = new Color(0, 100, 0);
                }
                else { catText.color = new Color(255, 0, 0); }
                catText.text = item.Slot.Count.ToString() + " / " + catCount.ToString();
                break;
            case "Rat":
                if (item.Slot.Count == ratCount)
                {
                    ratText.color = new Color(0, 100, 0);
                }
                else { ratText.color = new Color(255, 0, 0); }
                ratText.text = item.Slot.Count.ToString() + " / " + ratCount.ToString();
                break;
        }

    }
}
