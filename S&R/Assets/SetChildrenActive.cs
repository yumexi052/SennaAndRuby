using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrenActive : MonoBehaviour
{
    //public GameObject childObject;
    private bool isChildrenActive = false;
    private float timer = 0.0f;

    void Awake()
    {
        isChildrenActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Skill") != 0 && !isChildrenActive && !foxAnimation.died)
        {
            isChildrenActive = true;
        }

        if (isChildrenActive)
        {
            timer += Time.deltaTime;
            gameObject.transform.Find("Lights").gameObject.SetActive(true);
        }

        if (timer > 5)
        {
            isChildrenActive = false;
            gameObject.transform.Find("Lights").gameObject.SetActive(false);
            timer = 0.0f;
        }
    }
}
