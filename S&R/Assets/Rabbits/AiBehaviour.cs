using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 20f;

    private bool isWandering = false;
    private bool isRuning = false;
    private bool isRatateToLeft = false;
    private bool isRatateToRight = false;


    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRatateToRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRatateToLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRuning == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
            animator.SetBool("isWalking", true);
        }
        if (isRuning == false)
        {
            animator.SetBool("isWalking", false);
        }
    }

    IEnumerator Wander()
    {
        int RotationTime = Random.Range(1, 3);
        int RotationWait = Random.Range(1, 3);
        int RotationDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);
        
        isWandering = true;
        yield return new WaitForSeconds(walkWait);

        isRuning = true;
        yield return new WaitForSeconds(walkTime);

        isRuning = false;
        yield return new WaitForSeconds(RotationWait);

        if (RotationDirection == 1)
        {
            isRatateToLeft = true;
            yield return new WaitForSeconds(RotationTime);
            isRatateToLeft = false;
        }

        if (RotationDirection == 2)
        {
            isRatateToRight = true;
            yield return new WaitForSeconds(RotationTime);
            isRatateToRight = false;
        }

        isWandering = false;
    }

    
}
