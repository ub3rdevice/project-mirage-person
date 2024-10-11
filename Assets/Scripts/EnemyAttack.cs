using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float dmg = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() //this is the name of event that you've to manually add on animation track on desired timeframe
    {
        if (target == null) { return; }
        target.PlayerTakeDamage(dmg);
    }
   
}
