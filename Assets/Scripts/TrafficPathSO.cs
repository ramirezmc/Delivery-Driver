using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Traffic Path", fileName = "New Traffic Path")]
public class TrafficPathSO : ScriptableObject
{
    [SerializeField] Transform trafficPath;
    [SerializeField] float moveSpeed = 10f;

    public Transform GetStartingWaypoint()
    {
        return trafficPath.GetChild(0);
    }

    public Transform GetPath(int elementNumber)
    {
        return trafficPath.GetChild(elementNumber);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform point in trafficPath)
        {
            waypoints.Add(point);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
