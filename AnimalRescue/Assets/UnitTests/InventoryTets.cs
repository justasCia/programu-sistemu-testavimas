using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WindowsInput;
using WindowsInput.Native;

public class InventoryTets
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator InteractWithItem_EmptyInventoryInteractWithDog_AddsDogToFirstSlot()
    {
        GameObject playerGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Player"));
        var player = playerGameObject.GetComponent<interacting>();
        GameObject.Instantiate(Resources.Load<GameObject>("Inventory"));

        GameObject dogGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Dog"));
        var dog = dogGameObject.GetComponent<Dog>();
        player.mInteractItem = dog;
        player.InteractWithItem();

        Assert.That(player.Inventory.mSlots[0].Count == 1);
        Assert.That(player.Inventory.mSlots[0].FirstItem is Dog);
        yield return null;
        player.Inventory.RemoveItem(dog);
    }

    [UnityTest]
    public IEnumerator InteractWithItem_AlreadyHasOneDogInMSlotsInterractWithDog_AddsDogToFirstSlotInStack()
    {
        GameObject playerGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Player"));
        var player = playerGameObject.GetComponent<interacting>();
        GameObject.Instantiate(Resources.Load<GameObject>("Inventory"));

        GameObject dogGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Dog"));
        var dog = dogGameObject.GetComponent<Dog>();
        var inventory = player.Inventory;
        inventory.mSlots[0].AddItem(dog);

        var dogGameObject2 = GameObject.Instantiate(Resources.Load<GameObject>("Dog"));
        var dog2 = dogGameObject2.GetComponent<Dog>();
        player.mInteractItem = dog2;
        player.InteractWithItem();

        Assert.That(inventory.mSlots[0].Count == 2);
        yield return null;
        inventory.RemoveItem(dog);
        inventory.RemoveItem(dog2);
    }

    [UnityTest]
    public IEnumerator InteractWithItem_AlreadyHasOneDogInMSlotsInterractWithCat_AddsCatToSecondSlot()
    {
        GameObject playerGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Player"));
        var player = playerGameObject.GetComponent<interacting>();
        GameObject.Instantiate(Resources.Load<GameObject>("Inventory"));

        GameObject dogGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Dog"));
        var dog = dogGameObject.GetComponent<Dog>();
        var inventory = player.Inventory;
        inventory.mSlots[0].AddItem(dog);

        GameObject catGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Cat"));
        var cat = catGameObject.GetComponent<Cat>();

        player.mInteractItem = cat;
        player.InteractWithItem();

        Assert.That(inventory.mSlots[0].FirstItem is Dog);
        Assert.That(inventory.mSlots[1].FirstItem is Cat);
        yield return null;
        inventory.RemoveItem(dog);
        inventory.RemoveItem(cat);
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

    [UnityTest]
    public IEnumerator test()
    {
        GameObject playerGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Player"));
        var player = playerGameObject.GetComponent<interacting>();
        GameObject.Instantiate(Resources.Load<GameObject>("Inventory"));
        var hotbarObject = GameObject.Instantiate(Resources.Load<GameObject>("Hotbar"));
        yield return null;

        player.Inventory.ItemAdded += hotbarObject.GetComponent<Hotbar>().InventoryScript_ItemAdded;
        yield return null;
        player.Inventory.ItemUsed += playerGameObject.GetComponent<interacting>().Inventory_ItemUsed;
        yield return null;

        GameObject dogGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Dog"));
        var dog = dogGameObject.GetComponent<Dog>();
        player.mInteractItem = dog;
        player.InteractWithItem();

        yield return null;

        GameObject catGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Cat"));
        var cat = catGameObject.GetComponent<Cat>();
        player.mInteractItem = cat;
        player.InteractWithItem();

        yield return null;

        InputSimulator inputSimulator = new InputSimulator();
        //Debug.Log(player.mCurrentItem);
        //inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1);
        yield return new WaitForSeconds(5);
        Debug.Log(player.mCurrentItem);
        yield return null;
    }
}
