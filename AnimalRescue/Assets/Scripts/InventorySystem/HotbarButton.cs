using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HotbarButton : MonoBehaviour
{
    public Inventory inventory;
    public KeyCode keyCode;
    public interacting interacting;
    private Button button;
    public UnityEvent losePower;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(keyCode))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    private InventoryItemBase AttachedItem
    {
        get
        {
            ItemDragHandler dragHandler =
            gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();
            return dragHandler.Item;
        }
    }

    public void OnItemClicked()
    {
        InventoryItemBase item = AttachedItem;
        
        if (item != null)
        {
            GameObject.FindWithTag("Player").GetComponent<PowerManager>().LosePower();
            inventory.UseItem(item);
            interacting.equiped = true;
            interacting.animal = item.transform;
            //Debug.Log(item.name + " selected");
        }
    }
}
