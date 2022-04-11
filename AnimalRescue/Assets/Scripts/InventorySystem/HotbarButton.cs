using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarButton : MonoBehaviour
{
    public Inventory inventory;
    public KeyCode keyCode;
    public interacting interacting;
    private Button button;

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
            Debug.Log(dragHandler);
            return dragHandler.Item;
        }
    }

    public void OnItemClicked()
    {
        InventoryItemBase item = AttachedItem;
        
        if (item != null)
        {
            Debug.Log(item.Name);
            inventory.UseItem(item);
            interacting.equiped = true;
            interacting.animal = item.transform;
        }
    }
}
