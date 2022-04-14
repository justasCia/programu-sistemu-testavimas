using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorRoomMngr : MonoBehaviour
{
    public string combinationToGet = "1234";
    public ColorChange[] colors = new ColorChange[4];
    int[] combinationValues = new int[4];
    public string combination = "0000";
    public UnityEvent correct;

    [Header("For generated code")]
    public Material[] combColors = new Material[4];
    public Color[] colorsToChangeComb = new Color[4];

    private void Start()
    {
        GenerateComb();
        UpdateCombination();
    }


    void GenerateComb()
    {
        int code;
        combinationToGet = "";
        for (int i = 0; i < 4; i++)
        {
            code = Random.Range(0, 3);
            combinationToGet += code;
            combColors[i].color = colorsToChangeComb[code];
        }

    }

    public void UpdateCombination()
    {
        for (int i = 0; i < 4; i++) {
            combinationValues[i] = colors[i].currentColor;
        }
        combination = $"{combinationValues[0]}{combinationValues[1]}{combinationValues[2]}{combinationValues[3]}";

        if (combinationToGet.Equals(combination))
        {
            correct.Invoke();
        }
    }
}
