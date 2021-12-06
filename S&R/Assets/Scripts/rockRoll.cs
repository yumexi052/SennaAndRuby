using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class rockRoll : MonoBehaviour
{
    public int moveSpeed = 3;
    private float forceValue = 20f;
    public static bool isHit = false;
    Rigidbody rigidbody;
    public static bool destroyRock = false;
    //public AudioClip hitSound;
    //public AudioClip resetSound;

    void Awake()
    {
        destroyRock = false;
    }

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

        if (foxMove.isRockDestroy && rockSpawn.noOfEnemy >= 1 && !foxAnimation.died)
        //if (foxMove.isRockDestroy && rockSpawn.noOfEnemy >= 1 && !foxAnimation.died && !lightOff.isLightOff)
        {
            //lightOff.isLightOff = true;
            destroyRock = true;
            Destroy(gameObject);
            //foxMove.isRockDestroy = false;
        }

        if(rockSpawn.noOfEnemy == 0)
        {
            destroyRock = false;
        }
        //if (this.transform.position.y < 21.0f)
        //{ 
        //    destroyRock = true;
        //    Destroy(gameObject, 5);
        //    foxMove.isRockDestroy = false;
        //}


        //if (rockSpawn.isRockRestart)
        //{
        //    rockSpawn.isRockRestart = true;
        //    Destroy(gameObject);
        //    destroyRock = true;
        //}
    }

    //IEnumerator Again()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    DestroyObjectDelayed();
    //}

    //void DestroyObjectDelayed()
    //{
    //    // Kills the game object in 1 second after loading the object
    //    Destroy(gameObject, 3);
    //    destroyRock = true;
    //    foxMove.isRockDestroy = false;
    //}
}
