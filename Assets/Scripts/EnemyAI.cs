using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float enemyChaseRange = 5.5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= enemyChaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) //stopping distance can be configured via editor
        {
            ChaseTarget();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true); //string ref is meh
        Debug.Log($"{name} has hit {target.name}!");
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false); 
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,enemyChaseRange);
    }
}
