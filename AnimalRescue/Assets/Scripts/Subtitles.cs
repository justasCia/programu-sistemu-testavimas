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
        public float duration;
    }

    [SerializeField] List<Line> lines;
    public TextMeshProUGUI subtitles;
    public GameObject subtitlesPanel;

    int index = 0;
    bool isShowing = false;


    // Start is called before the first frame update
    void Start()
    {
        subtitles.text = "";
        index = 0;
    }

    public void ShowLine()
    {
        if (!isShowing && index < lines.Count)
        {
            isShowing = true;
            subtitles.text = index.ToString();
            Debug.Log(index);
            subtitlesPanel.SetActive(true);
            isShowing = false;
            index++;
            //StartCoroutine(Show(lines[index]));
        }

    }

    IEnumerator Show(Line line)
    {
        yield return new WaitForSeconds(line.duration);
        subtitlesPanel.SetActive(false);
        isShowing = false;
        index++;
    }
}
