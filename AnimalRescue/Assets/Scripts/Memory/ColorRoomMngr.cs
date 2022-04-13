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

    private void Start()
    {
        UpdateCombination();
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
