using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficAI : MonoBehaviour
{
    [SerializeField] TrafficPathSO trafficPath;
    [SerializeField] float rotationSpeed = 90f;
    List<Transform> waypoints;
    int waypointIndex = 0;
    
    void Start()
    {
        waypoints = trafficPath.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
        
    }
    void Update()
    {
        LookAtPath();
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = trafficPath.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
            if (waypointIndex == waypoints.Count)
            {
                waypointIndex = 0;
            }
        }
    }
    void LookAtPath()
    {
        Transform pathPoint = trafficPath.GetPath(waypointIndex);
        Vector3 vectorToTarget = pathPoint.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationSpeed;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * trafficPath.GetMoveSpeed());
    }
}
