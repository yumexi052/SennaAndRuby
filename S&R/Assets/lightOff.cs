using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOff : MonoBehaviour
{
    public Light light;
    public static bool isLightOff = false;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (foxMove.isRockDestroy && light.enabled)
        {
            light.enabled = false;
            isLightOff = true;
        }
    }
}
