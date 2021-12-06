using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyRock : MonoBehaviour
{
    public static bool isDestroyRock = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rock")
        {
            isDestroyRock = true;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
