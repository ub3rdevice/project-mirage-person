using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Transform player;

    void OnCollisionEnter(Collision other) 
    {
        if(player)
        {
            Debug.Log("You've picked up it!");
            Destroy(gameObject);
        }
        
    }
}
