using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndMngr : MonoBehaviour
{
    //List<string> times;

    private void Start()
    {
        Time.timeScale = 1f;
        Debug.Log(TotalTimer.FinalTime());
        //TotalTimer.InitiateTable();
        //times = TotalTimer.GetTable();
    }

    public void LoadMenu()
    {
        Scenes.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HighScore()
    {

    }

    public void SaveScore()
    {
        TotalTimer.SaveScore();
    }
}
