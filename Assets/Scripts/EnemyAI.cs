using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float enemyChaseRange = 5.5f;
    [SerializeField] float turnSpeed = 4.5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distanceToTarget = UnityEngine.Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= enemyChaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        RotateToTarget();

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

    void RotateToTarget()
    {
        UnityEngine.Vector3 direction = (target.position - transform.position).normalized;
        UnityEngine.Quaternion lookRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(direction.x, 0, direction.z));
        transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
