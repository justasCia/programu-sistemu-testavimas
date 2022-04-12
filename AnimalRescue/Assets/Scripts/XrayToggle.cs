using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class XrayToggle : MonoBehaviour
{
    public UniversalRendererData rendererSettings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rendererSettings.rendererFeatures[0].SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.X))
            rendererSettings.rendererFeatures[0].SetActive(false);
    }
}
