using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.SceneManagement;
using NUnit.Framework.Interfaces;

public class ButtonsTest
{
    [UnityTest]
    public IEnumerator PressButton_PressesButton_ButtonIsPressed()
    {
        var button = GameObject.Instantiate(Resources.Load<GameObject>("Button"));
        yield return null;

        button.GetComponent<Interactable>().onInteract.Invoke();
        var isPressed = button.GetComponent<ButtonObj>().isPressed;

        Assert.IsTrue(isPressed);
        yield return null;
    }
    [UnityTest]
    public IEnumerator PressButton_PressesButton_DoorOpens()
    {
        var door = Resources.Load<GameObject>("Door");
        var button = GameObject.Instantiate(Resources.Load<GameObject>("ButtonDoor"));
        yield return null;

        button.GetComponent<Interactable>().onInteract.Invoke();
        yield return null;

        var isOpen =door.GetComponent<DoorManager>().IsOpen;

        Assert.That(isOpen == true);
        yield return null;
    }
}
