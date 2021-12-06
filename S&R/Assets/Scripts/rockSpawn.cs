using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawn : MonoBehaviour
{
    public GameObject rock;
    private float timer = 0.0f;
    public static int noOfEnemy = 1;
    //public static bool isRockRestart = false;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject temp = Instantiate(rock, transform.position, transform.rotation);
        temp.name = "Rock";
    }

    // Update is called once per frame
    void Update()
    {

        if (rockRoll.destroyRock)
        {
            noOfEnemy = 0;
            //rockRoll.destroyRock = false;
        }

        if (noOfEnemy == 0)
        {
            timer += Time.deltaTime;
        }

        if (timer > 7)
        {
            GameObject temp = Instantiate(rock, transform.position, transform.rotation);
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

        if (foxMove.isControlDestroy)
        {
            Destroy(gameObject);
        }
    }
}
