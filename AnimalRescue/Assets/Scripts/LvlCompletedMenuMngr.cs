using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCompletedMenuMngr : MonoBehaviour
{
    

    public void LoadNextScene(bool lastLvl)
    {
        if (!lastLvl)
            Scenes.LoadNextScene();
        else
            Scenes.LoadScene(0);
    }

    public void LoadMainMenu()
    {
        Scenes.LoadScene(0);
    }
}
