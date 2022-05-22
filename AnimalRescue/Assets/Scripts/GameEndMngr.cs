using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndMngr : MonoBehaviour
{
    public void LoadMenu()
    {
        Scenes.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
