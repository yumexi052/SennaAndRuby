using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ai : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWayPoint;
    private int targetWayPointIndex=0;
    private float minDis = 0.1f;
    private float lastWayPointIndex;

    private float movementSpeed = 2.0f;
    private float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWayPointIndex = waypoints.Count - 1;
        targetWayPoint = waypoints[targetWayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        float distance = Vector3.Distance(transform.position, targetWayPoint.position);
        checkDistanceWaypoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, movementStep);

    }

    void checkDistanceWaypoint(float currentDistance)
    {
        if (currentDistance <= minDis)
        {
            targetWayPointIndex++;
            updateTargetWaypoint();
        }
    }

    void updateTargetWaypoint()
    {
        if (targetWayPointIndex > lastWayPointIndex)
        {
            targetWayPointIndex = 0;
        }
        targetWayPoint = waypoints[targetWayPointIndex];
    }
}
