using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    //public Animator animator;
    public Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (foxMove.trapTrigger)
        {
            animation.CrossFade("Anim_TrapNeedle_Play");
        }
        else
            animation.CrossFade("Anim_TrapNeedle_Idle");
    }
}
