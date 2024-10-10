using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HP = 100f;


    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken", damage); //string ref is bad, mmkay
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
