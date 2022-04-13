using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LampRoomMng : MonoBehaviour
{
    public string[] combinationsToGet = {"032", "4101", "33023"};
    public string currentCombToGet = "";
    public ActivateLamp[] lamps = new ActivateLamp[5];
    public ButtonObj[] buttons = new ButtonObj[5];
    //public ColorChange[] colors = new ColorChange[4];
    List<int> currentComb = new List<int>();
    public string combination = "";
    public float interval = 2f;
    public UnityEvent correct;

    public bool roundActive = false;
    int currentRound = 0;
    public ConfirmLamp confLamp;

    private void Start()
    {
        currentCombToGet = combinationsToGet[0];
    }

    public void StartRound()
    {
        if (!roundActive)
        {
            roundActive = true;
            ResetValues();
            DeactivateBtns();
            //currentCombToGet = combinationsToGet[currentRound];
            Round(StringToInt(currentCombToGet));
            
        }
    }


    public void Round(List<int> combToGet)
    {
        StartCoroutine(ShowComb(interval, combToGet));
    }

    public void UpdateCombination(int lampId)
    {
        currentComb.Add(lampId);
        combination += lampId;
        if (currentComb.Count == StringToInt(currentCombToGet).Count)
        {
            if (currentCombToGet.Equals(IntToString(currentComb)))
            {
                Debug.Log("correct");
                confLamp.Corect();
                if (currentRound != combinationsToGet.Length-1)
                {
                    currentCombToGet = combinationsToGet[++currentRound];
                }
                else
                {
                    Debug.Log("complete");
                    correct.Invoke();
                }
            }
            else
            {
                Debug.Log("incorrect");
                confLamp.Incorrect();
            }
            ResetValues();
        }
    }

    void DeactivateBtns()
    {
        foreach (ButtonObj btn in buttons)
            btn.pressable = false;
    }
    
    void ActivateBtns()
    {
        foreach (ButtonObj btn in buttons)
            btn.pressable = true;
    }

    void ResetValues()
    {
        currentComb.Clear();
        combination = "";
    }

    List<int> StringToInt(string line)
    {
        char[] chs = line.ToCharArray();
        List<int> numbers = new List<int>();
        foreach (char ch in chs)
        {
            numbers.Add(int.Parse(ch.ToString()));
        }
        return numbers;
    }
    
    string IntToString(List<int> comb)
    {
        string line = "";
        foreach (int ch in comb)
        {
            line += ch;
        }
        return line;
    }
    IEnumerator ShowComb(float interval, List<int> combToGet)
    {
        foreach (int lampNr in combToGet)
        {
            yield return new WaitForSeconds(interval);
            lamps[lampNr].TurnOn();
            //Debug.Log(lampNr);
        }
        ActivateBtns();
        roundActive = false;
    }
}
