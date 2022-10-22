using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTets
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator InventoryTetsWithEnumeratorPasses()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var item = gameObject.AddComponent<InventoryItemBase>();

        inventory.AddItem(item);

        Assert.That(inventory.mSlots[0].Count == 1);
        yield return null;
    }
}
