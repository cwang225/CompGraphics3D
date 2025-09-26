using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask obstaclesLayers;
    public LayerMask objectsLayers;
    public Collider detectedObject;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        UnityEngine.Vector3 rightDirection = UnityEngine.Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);
        UnityEngine.Vector3 leftDirection = UnityEngine.Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position, distance, objectsLayers
        );

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            UnityEngine.Vector3 directionToController = UnityEngine.Vector3.Normalize(
                collider.bounds.center - transform.position
            );
            float angleToCollider = UnityEngine.Vector3.Angle(
                transform.forward, directionToController
            );

            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.red);
                }
            }
        }
    }
}
