using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Subtitles : MonoBehaviour
{
    [Serializable]
    private class Line
    {
        public string lineText;
        //public float duration;
    }

    [SerializeField] List<Line> lines;
    public TextMeshProUGUI subtitles;
    //public GameObject subtitlesPanel;

    int index = 0;
    //bool isShowing = false;


    // Start is called before the first frame update
    void Start()
    {
        subtitles.text = "";
        index = 0;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (index < lines.Count)
        {
            subtitles.text = lines[index].lineText;
            index++;
        }

    }

}
