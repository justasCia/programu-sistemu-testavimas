using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChange : MonoBehaviour
{
    public Material material;
    public List<Color> colors = new List<Color>();
    public int currentColor = 0;
    public UnityEvent UpdateComb;

    // Start is called before the first frame update
    void Start()
    {
        material.color = colors[currentColor];
    }

    public void ChangeColor()
    {
        if (currentColor == colors.Count - 1)
            currentColor = 0;
        else
            currentColor++;
        material.color = colors[currentColor];

        UpdateComb.Invoke();
    }
}
