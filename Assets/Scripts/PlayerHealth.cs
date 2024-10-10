using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float PlayerHP = 100f;

    public void PlayerTakeDamage(float dmg)
    {
        PlayerHP -= dmg;
        if(PlayerHP <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
