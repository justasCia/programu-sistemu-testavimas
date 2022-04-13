using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NumberChange : MonoBehaviour
{
    public TextMeshPro number;
    public int currentNumber = 0;
    public UnityEvent UpdateComb;

    private void Start()
    {
        number.text = currentNumber.ToString();
    }

    public void ChangeNumber()
    {
        if (currentNumber == 9)
            currentNumber = 0;
        else
            currentNumber++;
        number.text = currentNumber.ToString();

        UpdateComb.Invoke();
    }
}
