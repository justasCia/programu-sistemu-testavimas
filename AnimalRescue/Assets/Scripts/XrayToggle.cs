using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class XrayToggle : MonoBehaviour
{
    public UniversalRendererData rendererSettings;

    public float maxAmount = 100f;
    float currentAmount = 50f;
    public float useAmount = 0.5f;
    public Slider XrayBar;

    // Start is called before the first frame update
    void Start()
    {
        rendererSettings.rendererFeatures[0].SetActive(false);

        currentAmount = maxAmount;
        if (XrayBar != null)
        {
            XrayBar.maxValue = currentAmount;
            XrayBar.value = currentAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount > 0)
        {
            //if (Input.GetKeyDown(KeyCode.X))
            //XrayOn();
            if (Input.GetKey(KeyCode.X))
                XrayOn();
            else if (Input.GetKeyUp(KeyCode.X))
                XrayOff();
        }
        else
            XrayOff();
    }

    void XrayOn()
    {
        rendererSettings.rendererFeatures[0].SetActive(true);
        if (XrayBar != null)
        {
            currentAmount -= useAmount;
            XrayBar.value = currentAmount;
        }
    }

    void XrayOff()
    {
        rendererSettings.rendererFeatures[0].SetActive(false);

    }
}
