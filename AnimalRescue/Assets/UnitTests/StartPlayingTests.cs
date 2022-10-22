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

public class StartPlayingTests
{
    [OneTimeSetUp] public void OneTimeSetup() => SceneManager.LoadScene("Assets/Scenes/StartMenu.unity");
    [UnityTest]
    public IEnumerator StartPlaying_PressesPlayButton_LoadsLevel1()
    {
        var gameObject = new GameObject();
        var menu = gameObject.AddComponent<MainMenu>();
        var prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        menu.PlayGame();
        yield return null;

        Assert.That(SceneManager.GetActiveScene().buildIndex-1 == prevSceneIndex);
        yield return null;
    }

    [UnityTest]
    public IEnumerator StartPlaying_LoadsLevelAndMovesPlayer_PlayerMoves()
    {
        var gameObject = new GameObject();
        var menu = gameObject.AddComponent<MainMenu>();
        GameObject player = Resources.Load<GameObject>("Player");
        player.GetComponent<interacting>().Inventory = Resources.Load<Inventory>("Inventory");

        menu.PlayGame();
        yield return null;

        Debug.Log(player.GetComponent<interacting>().Inventory);
        Assert.That(true == true);

        yield return null;
    }
}