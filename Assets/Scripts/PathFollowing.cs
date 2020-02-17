using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public Transform path;

    private void OnDrawGizmos()
    {
        Vector3 startPosition = path.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        Gizmos.color = Color.red;
        
        foreach (Transform waypoint in path)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
