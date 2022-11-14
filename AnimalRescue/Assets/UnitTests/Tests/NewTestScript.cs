using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [Test]
    public void InteractWithItem_EmptyInventoryInteractWithDog_AddsDogToFirstSlot()
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
        //player.Inventory.RemoveItem(dog);
    }

    [Test]
    public void InteractWithItem_AlreadyHasOneDogInMSlotsInterractWithDog_AddsDogToFirstSlotInStack()
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
        inventory.RemoveItem(dog);
        inventory.RemoveItem(dog2);
    }

    [Test]
    public void InteractWithItem_AlreadyHasOneDogInMSlotsInterractWithCat_AddsCatToSecondSlot()
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
        inventory.RemoveItem(dog);
        inventory.RemoveItem(cat);
    }

    [Test]
    public void RemoveItem_ItemExists_RemovesItem()
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
    }

    [Test]
    public void RemoveItem_ItemDoesntExists_InventoryStaysTheSame()
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
    }
}
