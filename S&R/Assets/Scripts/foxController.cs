using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxController : MonoBehaviour
{
    //public Animator animator;
    public CharacterController controller;

    public float speed = 1.0f;
    private float runSpeed = 5.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetAxis("Run") != 0)
        {
            if (!foxAnimation.died)
            {
                controller.Move(move * runSpeed * Time.deltaTime);
            } 
        }
        else
        {
            if (!foxAnimation.died)
            {
                controller.Move(move * speed * Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (!foxAnimation.died)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }  
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}