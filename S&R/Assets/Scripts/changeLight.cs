using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLight : MonoBehaviour
{
    public Light lightObject;
    public Color myColor;
    private bool isLightChange = false;
    private float timer = 0.0f;
    Renderer rend;

    void Start()
    {
        //lightObject = GetComponent<Light>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetAxis("Skill") != 0 && !isLightChange && !foxAnimation.died)
        {
            lightObject.color = myColor;
            isLightChange = true;
            rend.material.color = myColor;
        }

        if (isLightChange)
        {
            timer += Time.deltaTime;
        }

        if (timer > 5)
        {
            isLightChange = false;
            lightObject.color = Color.white;
            rend.material.color = Color.white;
            timer = 0.0f;
        }
    }
}
