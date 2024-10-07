using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPVCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPVCamera.transform.position, FPVCamera.transform.forward,out hit, range))

        {
            Debug.Log($" Hit to => {hit.transform.name} ");
            // add vfx
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        
        else
        {
            return;
        } 
    }
}
