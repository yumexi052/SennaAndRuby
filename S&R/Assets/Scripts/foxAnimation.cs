using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxAnimation : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public static bool OnTheGround = true;
    public static bool rockSpeedUp = false;
    private float timer = 0.0f;
    private float timerDoor = 0.0f;
    public static bool trapTrigger = false;
    public static bool died = false;

    public Animator animator;//Animator Controller

    void Awake()
    {
        died = false;
        animator.SetBool("isDied", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isSkill", false);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isJump", false);
            timer += Time.deltaTime;
            if (timer > 3)
            {
                animator.SetBool("isSit", true);
            }
        }
        else
        {
            timer = 0.0f;
            animator.SetBool("isSit", false);
            movement();
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJump", true);

            }
            else
            {
                animator.SetBool("isJump", false);
            }
            if (Input.GetAxis("Skill") != 0)
            {
                animator.SetBool("isSkill", true);
            }
        }

        if (rockRoll.isHit || foxMove.trapTrigger)
        {
            died = true;
            animator.SetBool("isDied", true);
        }

        if (Input.GetAxis("Skill") != 0)
        {
            animator.SetBool("isSkill", true);
        }
    }

    private void movement()
    {
        if (Input.GetAxis("Run") != 0)
        {
            animator.SetBool("isRun", true);
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
            animator.SetBool("isRun", false);
        }

    }
}