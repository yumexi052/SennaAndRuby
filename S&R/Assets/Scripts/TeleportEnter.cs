using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnter : MonoBehaviour
{
    public string lastExitName;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString(lastExitName) == lastExitName)
        {
            playerTP.instance.transform.position = transform.position;
            playerTP.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
