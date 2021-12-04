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

    public Animator animator;//Animator Controller

    void Awake()
    {
        animator.SetBool("isDied", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
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
        }

        if (rockRoll.isHit)
        {
            animator.SetBool("isDied", true);
        }

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.black);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            if (hit.collider.gameObject.tag == "TrapFast")
            {
                rockSpeedUp = true;
                Debug.Log("TrapFast triggered");
            }
            if (hit.collider.gameObject.tag == "Door")
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Door triggered");
                timerDoor += Time.deltaTime;

            }
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