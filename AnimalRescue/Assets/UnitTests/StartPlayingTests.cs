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
using WindowsInput;
using WindowsInput.Native;

public class StartPlayingTests
{
    //[OneTimeSetUp] public void OneTimeSetup() => SceneManager.LoadScene("Assets/Scenes/StartMenu.unity");
    [UnityTest]
    [LoadScene("Assets/Scenes/StartMenu.unity")]
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
    [LoadScene("Assets/Scenes/Dovydo test.unity")]
    public IEnumerator StartPlaying_LoadsLevelAndMovesPlayer_PlayerMoves()
    {
        GameObject player = GameObject.Instantiate(Resources.Load<GameObject>("Player"));
        InputSimulator inputSimulator = new InputSimulator();
        var position = player.transform.position;

        inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
        yield return null;

        Assert.That(position != player.transform.position);

        yield return null;
    }
}
public class LoadSceneAttribute : NUnitAttribute, IOuterUnityTestAction
{
    private string scene;

    public LoadSceneAttribute(string scene) => this.scene = scene;

    IEnumerator IOuterUnityTestAction.BeforeTest(ITest test)
    {
        Debug.Assert(scene.EndsWith(".unity"));
        yield return EditorSceneManager.LoadSceneAsyncInPlayMode(scene, new LoadSceneParameters(LoadSceneMode.Single));
    }

    IEnumerator IOuterUnityTestAction.AfterTest(ITest test)
    {
        yield return null;
    }
}