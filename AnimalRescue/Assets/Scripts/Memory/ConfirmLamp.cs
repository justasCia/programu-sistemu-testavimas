using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmLamp : MonoBehaviour
{
    public Color correct;
    public Color incorrect;
    public Color waiting;
    public Material mat;
    public float interval = 1f;

    private void Start()
    {
        mat.color = waiting;
    }

    public void Corect()
    {
        StartCoroutine(ChangeColor(interval, correct, waiting));
    }

    public void Incorrect()
    {
        StartCoroutine(ChangeColor(interval, incorrect, waiting));
    }

    IEnumerator ChangeColor(float interval, Color color, Color waiting)
    {
        mat.color = color;
        yield return new WaitForSeconds(interval);
        mat.color = waiting;
    }
}
