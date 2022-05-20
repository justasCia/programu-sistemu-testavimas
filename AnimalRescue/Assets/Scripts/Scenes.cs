using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public static class Scenes
{

    public static async Task RestartScene()
    {
        await LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static async Task LoadNextScene()
    {
        await LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static async Task LoadPrevousScene()
    {
        await LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public static void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static async Task LoadScene(int buildIndex)
    {
        GameObject.Find("Transition").GetComponent<Animator>().SetTrigger("End");
        await Wait(1.1f);
        SceneManager.LoadScene(buildIndex);

    }


    static async Task Wait(float seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }
}
