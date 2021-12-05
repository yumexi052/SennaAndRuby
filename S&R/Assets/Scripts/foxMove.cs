using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class foxMove : MonoBehaviour
{
    public float speed = 3.0f;
    private float runSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public static bool OnTheGround = true;
    public static bool trapTrigger = false;
    public static bool rockSpeedUp = false;
    public static bool isRockDestroy = false;
    public static bool isControlDestroy = false;
    private float timer = 0.0f;
    private float timerDoor = 0.0f;

    public Animator animator;//Animator Controller
    //public Animation anim;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 rotationDirection;
    private float gravity = 9.8f;
    private float vSpeed = 0.0f;

    void Awake()
    {
        animator.SetBool("isDied", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isSkill", false);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            timer += Time.deltaTime;
            if (timer > 3)
            {
                animator.SetBool("isSit", true);
            }
            if (Input.GetAxis("Jump") == 0)
            {
                animator.SetBool("isJump", false);
            }
            else
            {
                Jump();
            }
        }
        else
        {
            timer = 0.0f;
            animator.SetBool("isSit", false);

            Move();
            if (Input.GetAxis("Jump") == 0)
            {
                animator.SetBool("isJump", false);
            }
            else
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.J))
            {
                animator.SetBool("isSkill", true);
            }
        }

        if (Input.GetKey(KeyCode.J))
            animator.SetBool("isSkill", true);
            

        if (rockRoll.isHit || trapTrigger)
        {
            animator.SetBool("isDied", true);
        }

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.black);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.tag == "Ground")
            {
                OnTheGround = true;
            }
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
            if (hit.collider.gameObject.tag == "TrapDanger")
            {
                trapTrigger = true;
                Debug.Log("TrapDanger triggered");
            }
            if (hit.collider.gameObject.tag == "Arrow" && Input.GetAxis("Collect") != 0)
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Rock Destroy");
                isRockDestroy = true;
            }
            if (hit.collider.gameObject.tag == "Sun" && Input.GetAxis("Collect") != 0)
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Main Control Destroy!");
                isControlDestroy = true;
                isRockDestroy = true;
            }
            //else
            //{
            //    GameObject door;
            //    door = GameObject.FindWithTag("Door");
            //    if (timerDoor > 3)
            //    {
            //        door.SetActive(true);
            //        Debug.Log("Door Closed");
            //        timerDoor = 0.0f;
            //    }   
            //}
        }
    }

    private void Move()
    {
        if (Input.GetAxis("Run") != 0 && !foxAnimation.died)
        {

            animator.SetBool("isSkill", false);
            animator.SetBool("isRun", true);
            animator.SetBool("isWalk", false);
            float moveZ = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(0, 0, moveZ);
            moveDirection *= runSpeed;
            moveDirection = transform.TransformDirection(moveDirection);

            rotationDirection = new Vector3(0, rotation, 0);
            transform.Rotate(this.rotationDirection);

            //if (Input.GetAxis("Jump") != 0 && characterController.isGrounded)
            //{
            //    animator.SetBool("isJump", true);
            //    vSpeed = 5;
            //}

            vSpeed -= gravity * Time.deltaTime;
            moveDirection.y = vSpeed;
            characterController.Move(moveDirection * Time.deltaTime);

        }
        else if (Input.GetAxis("Walk") != 0 && !foxAnimation.died)
        {
            animator.SetBool("isSkill", false);
            animator.SetBool("isWalk", true);
            animator.SetBool("isRun", false);
            float moveZ = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(0, 0, moveZ);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            rotationDirection = new Vector3(0, rotation, 0);
            transform.Rotate(this.rotationDirection);

            //if (Input.GetAxis("Jump") != 0 && characterController.isGrounded)
            //{
            //    animator.SetBool("isJump", true);
            //    vSpeed = 5;
            //}

            vSpeed -= gravity * Time.deltaTime;
            moveDirection.y = vSpeed;
            characterController.Move(moveDirection * Time.deltaTime);

        }

    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") != 0 && characterController.isGrounded)
        {
            animator.SetBool("isSkill", false);
            animator.SetBool("isJump", true);
            float moveZ = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(0, 0, moveZ);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            rotationDirection = new Vector3(0, rotation, 0);
            transform.Rotate(this.rotationDirection);

            vSpeed = 5;
            vSpeed -= gravity * Time.deltaTime;
            moveDirection.y = vSpeed;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
