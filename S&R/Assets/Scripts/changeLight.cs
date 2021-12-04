using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLight : MonoBehaviour
{
    Light lightObject;
    public Color myColor;
    private bool isLightChange = false;
    private float timer = 0.0f;

    void Start()
    {
        lightObject = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J) && !isLightChange)
        {
            lightObject.color = myColor;
            isLightChange = true;
            
        }

        if (isLightChange)
        {
            timer += Time.deltaTime;
        }

        if (timer > 5)
        {
            isLightChange = false;
            lightObject.color = Color.white;
            timer = 0.0f;
        }
    }
}
