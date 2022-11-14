/***
 * Author: Brennan Gillespie
 * Created: 11/14/2022
 * Modified:
 * Desciption: move to desitination
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class FollowDestination : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent ThisAgent;
    public Transform Destination;

    void Awake()
    {
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ThisAgent.SetDestination(Destination.position); // 
    }
}
