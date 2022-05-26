using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTable : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI table;
    List<string> times = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        title.text = "Your time: " + TotalTimer.FinalTime();
        table.text = "";
        TotalTimer.InitiateTable();
        times = TotalTimer.GetTable();
        WriteTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteTable()
    {
        string text = "";
        foreach(string line in times)
        {
            text += line + "\n";
        }
        table.text = text;
    }

    public void Save()
    {
        TotalTimer.SaveScore();
        WriteTable();
    }
}
