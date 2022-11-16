using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class SightLine : MonoBehaviour
{
    //private bool IsTargetInSight = false;

    public Transform EyePoint;
    public string TargetTag = "Player";
    public float FieldOfView = 45f;

    public bool IsTargetInSightLine { get; set; } = false;

    public Vector3 LastKnownSighting { get; set; } = Vector3.zero;

    private SphereCollider ThisCollider;

    void awake()
    {
        ThisCollider = GetComponent<SphereCollider>();
        LastKnownSighting = transform.position;
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 DirToTarget = target.position - EyePoint.position;
        float angle = Vector3.Angle(EyePoint.forward, DirToTarget);

        if(angle <= FieldOfView)
        {
            return true;
        }
        return false;
    }

    private bool HasClearLineOfSightToTarget(Transform target)
    {
        RaycastHit info;


        Vector3 DirToTarget = (target.position).normalized;

        if(Physics.Raycast(EyePoint.position, DirToTarget, out info, ThisCollider.radius))
        {
            if (info.transform.CompareTag(TargetTag))
            {
                return true;
            } 
        }
        return false;
    }

    private void UpdateSight(Transform target)
    {
        IsTargetInSightLine = HasClearLineOfSightToTarget(target) && TargetInFOV(target);
        if (IsTargetInSightLine)
        {
            LastKnownSighting = target.position;
        }
    }
    
    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag(TargetTag))
        {
            UpdateSight(other.transform);
            Debug.Log("Stay");
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(TargetTag))
        {
            IsTargetInSightLine = false;
        }
    }
}
