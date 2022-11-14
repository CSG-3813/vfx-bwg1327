/***
 * Author
 * created
 * modified
 * Description:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent), typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent ThisNavMeshAgent;
    private Animator ThisAnimator;

    public float runVelocity = 0.1f;
    public string animationRunParameter;
    public string animationSpeedParameter;
    private float MaxSpeed;

    void Awake()
    {
        ThisNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
        MaxSpeed = ThisNavMeshAgent.speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ThisAnimator.SetBool(animationRunParameter, ThisNavMeshAgent.velocity.magnitude > runVelocity);
        ThisAnimator.SetFloat(animationSpeedParameter, ThisNavMeshAgent.velocity.magnitude / MaxSpeed);
    }
}
