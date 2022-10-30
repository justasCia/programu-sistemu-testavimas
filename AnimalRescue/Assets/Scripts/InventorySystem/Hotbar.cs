using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hotbar : MonoBehaviour
{

    public Inventory Inventory;
    public GameObject MessagePanel;
    public AnimalCount animalCount;

    // Use this for initialization
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Debug.Log(e.Item);
        Transform inventoryPanel = transform.Find("InventoryPanel");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;
            // Border... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            TextMeshProUGUI txtCount = textTransform.GetComponent<TextMeshProUGUI>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            Debug.Log(itemDragHandler);

            if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";
                if (animalCount != null)
                {
                    animalCount.UpdateCount(e.Item);
                }
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;

            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);

            Image image = imageTransform.GetComponent<Image>();
            TextMeshProUGUI txtCount = textTransform.GetComponent<TextMeshProUGUI>();

            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            // We found the item in the UI
            if (itemDragHandler.Item == null)
                continue;


            // Found the slot to remove from
            if (e.Item.Slot.Id == index)
            {
                int itemCount = e.Item.Slot.Count;
                //Debug.Log(itemCount);
                itemDragHandler.Item = e.Item.Slot.FirstItem;
                if (itemCount < 2)
                {
                    txtCount.text = "";
                }
                else
                {
                    txtCount.text = itemCount.ToString();
                }
                animalCount.UpdateCount(e.Item);
                if (itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }
                break;
            }

        }
    }

    private bool mIsMessagePanelOpened = false;

    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel(InteractableItemBase item)
    {
        MessagePanel.SetActive(true);

        TextMeshProUGUI mpText = MessagePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        mpText.text = item.InteractText;

        mIsMessagePanelOpened = true;

    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = text;


        mIsMessagePanelOpened = true;
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
        mIsMessagePanelOpened = false;
    }
}
