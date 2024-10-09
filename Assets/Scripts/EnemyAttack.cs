using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float dmg = 40f;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        
        Debug.Log("Boom, headshot!");
    }
   
}
