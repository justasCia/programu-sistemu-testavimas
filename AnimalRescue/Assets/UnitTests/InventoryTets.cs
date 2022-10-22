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
    public IEnumerator AddItem_EmptyMSlotsAddDog_AddsDogToFirstSlot()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var dog = gameObject.AddComponent<Dog>();

        inventory.AddItem(dog);

        Assert.That(inventory.mSlots[0].Count == 1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItem_AlreadyHasOneDogInMSlotsAddDog_AddsDogToFirstSlotInStack()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var dog1 = gameObject.AddComponent<Dog>();
        inventory.mSlots[0].AddItem(dog1);
        var dog2 = gameObject.AddComponent<Dog>();

        inventory.AddItem(dog2);

        Assert.That(inventory.mSlots[0].Count == 2);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItem_DogInFirstSlotAddCat_AddsCatToSecondSlot()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var dog = gameObject.AddComponent<Dog>();
        dog.Name = "Dog";
        inventory.mSlots[0].AddItem(dog);

        //Debug.Log(inventory.mSlots[0].FirstItem.GetType());
        var cat = gameObject.AddComponent<Cat>();
        cat.Name = "Cat";
        inventory.AddItem(cat);

        Assert.That(inventory.mSlots[0].FirstItem is Dog);
        Assert.That(inventory.mSlots[1].FirstItem is Cat);
        yield return null;
    }

    [UnityTest]
    public IEnumerator RemoveItem_ItemExists_RemovesItem()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var dog = gameObject.AddComponent<Dog>();
        dog.Name = "Dog";
        inventory.AddItem(dog);
        var cat = gameObject.AddComponent<Cat>();
        cat.Name = "Cat";
        inventory.AddItem(cat);

        inventory.RemoveItem(dog);

        Assert.That(inventory.mSlots[0].FirstItem is null);
        Assert.That(inventory.mSlots[1].FirstItem is Cat);
        yield return null;
    }

    [UnityTest]
    public IEnumerator RemoveItem_ItemDoesntExists_InventoryStaysTheSame()
    {
        var gameObject = new GameObject();
        var inventory = gameObject.AddComponent<Inventory>();
        var dog = gameObject.AddComponent<Dog>();
        dog.Name = "Dog";
        inventory.AddItem(dog);
        var cat = gameObject.AddComponent<Cat>();
        cat.Name = "Cat";
        inventory.AddItem(cat);

        var rat = gameObject.AddComponent<Rat>();
        rat.Name = "rat";
        inventory.RemoveItem(rat);

        Assert.That(inventory.mSlots[0].FirstItem is Dog);
        Assert.That(inventory.mSlots[1].FirstItem is Cat);
        yield return null;
    }
}
