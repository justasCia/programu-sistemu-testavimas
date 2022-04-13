using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberRoomMngr : MonoBehaviour
{
    public string combinationToGet = "123";
    public NumberChange[] numbers = new NumberChange[3];
    int[] combinationValues = new int[3];
    public string combination = "000";
    public UnityEvent correct;

    private void Start()
    {
        UpdateCombination();
    }

    public void UpdateCombination()
    {
        for (int i = 0; i < 3; i++)
        {
            combinationValues[i] = numbers[i].currentNumber;
        }
        combination = $"{combinationValues[0]}{combinationValues[1]}{combinationValues[2]}";

    }

    public void Verify()
    {
        if (combinationToGet.Equals(combination))
        {
            Debug.Log("correct");
            correct.Invoke();
        }
        else
        {
            Debug.Log("incorrect");
        }
    }
}
