using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn2 : MonoBehaviour
{
    public GameObject rock;
    private float timer = 0.0f;
    public static int noOfEnemy = 0;
    //public static bool isRockRestart = false;

    // Start is called before the first frame update
    void Awake()
    {
        //GameObject temp = Instantiate(rock, transform.position, transform.rotation);
        //temp.name = "Rock";
    }

    // Update is called once per frame
    void Update()
    {

        if (rockRoll.destroyRock || AutoDestroyRock.isDestroyRock)
        {
            noOfEnemy = 0;
            AutoDestroyRock.isDestroyRock = false;
            //rockRoll.destroyRock = false;
        }

        if (noOfEnemy == 0)
        {
            timer += Time.deltaTime;
        }

        if (timer > 5)
        {
            //int spawnPointX = Random.Range(50, 58);
            int spawnPointX = Random.Range(-8, 12);
            //int spawnPointZ = Random.Range(600, 700);
            Vector3 spawnPosition = new Vector3(spawnPointX, transform.position.y, transform.position.z);

            GameObject temp = Instantiate(rock, spawnPosition, transform.rotation);
            temp.name = "Rock";
            timer = 0.0f;
            noOfEnemy++;

            if (temp.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("Component missing!");
                temp.AddComponent<Rigidbody>();
                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), temp.GetComponent<Collider>(), true);
            }
        }
    }
}
