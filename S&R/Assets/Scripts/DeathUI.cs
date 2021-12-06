using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    void Start()
    {
        Debug.Log("btn work");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(foxMove.lastScene);

    }
}
