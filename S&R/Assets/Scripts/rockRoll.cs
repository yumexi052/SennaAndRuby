using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class rockRoll : MonoBehaviour
{
    public int moveSpeed = 3;
    private float forceValue = 5f;
    public static bool isHit = false;
    Rigidbody rigidbody;
    public static bool destroyRock = false;
    //public AudioClip hitSound;
    //public AudioClip resetSound;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fox")
        {
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.clip = hitSound;
            //audio.Play();
            isHit = true;
        }
    }

    void Update()
    {
        if (foxMove.rockSpeedUp)
        {
            rigidbody.AddForce(0, -forceValue, 0, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.E) && rockSpawn.noOfEnemy >= 1)
        {
            destroyRock = true;
            Destroy(gameObject);
        }
    }
}
