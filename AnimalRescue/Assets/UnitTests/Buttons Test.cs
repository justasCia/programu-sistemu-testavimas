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
        var button = GameObject.Instantiate(Resources.Load<GameObject>("ButtonDoor"));
        var door = GameObject.Instantiate(Resources.Load<GameObject>("Door"));
        yield return null;

        //button.GetComponent<Interactable>().onInteract.Invoke();
        
        button.GetComponent<ButtonObj>().Pressed();
        yield return new WaitForSeconds(10);

        var isOpen = door.GetComponent<DoorManager>().IsOpen;

        Assert.That(isOpen == true);
        yield return null;
    }
}
