using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    //private Stack<InventoryItemBase> mItemStack = new Stack<InventoryItemBase>();
    private List<InventoryItemBase> mItemStack = new List<InventoryItemBase>();

    private int mId = 0;

    public InventorySlot(int id)
    {
        mId = id;
    }

    public int Id
    {
        get { return mId; }
    }

    public void AddItem(InventoryItemBase item)
    {
        item.Slot = this;
        //mItemStack.Push(item);
        mItemStack.Add(item);
    }

    public InventoryItemBase FirstItem
    {
        get
        {
            if (IsEmpty)
                return null;

            //return mItemStack.Peek();
            return mItemStack[mItemStack.Count - 1];
        }
    }

    public bool IsStackable(InventoryItemBase item)
    {
        if (IsEmpty)
            return false;

        //InventoryItemBase first = mItemStack.Peek();
        InventoryItemBase first = mItemStack[mItemStack.Count - 1];

        if (first.Name == item.Name)
            return true;

        return false;
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public int Count
    {
        get { return mItemStack.Count; }
    }

    public bool Remove(InventoryItemBase item)
    {
        if (IsEmpty)
            return false;

        //InventoryItemBase first = mItemStack.Peek();
        //Debug.Log(first.name + " rem");
        //if (first.name == item.name)
        //{
            //Debug.Log(item.gameObject.name + " removed, items " + mItemStack.Count);
            //mItemStack.Pop();
            bool a = mItemStack.Remove(item);
            Debug.Log(a);
            return a;
        //}
        //return false;
    }
    
    public string ItemName()
    {
        //InventoryItemBase first = mItemStack.Peek();
        InventoryItemBase first = mItemStack[mItemStack.Count - 1];
        return first.name;
    }
}
