using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPVCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject impactVFX;

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
        PlayMuzzleflashVFX();
        ProcessRaycast();
    }

    void PlayMuzzleflashVFX()
    {
        muzzleflash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPVCamera.transform.position, FPVCamera.transform.forward, out hit, range))

        {
            ProcessImpactVFX(hit);
            
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }

        else
        {
            return;
        }
    }

    void ProcessImpactVFX(RaycastHit hit)
    {
        GameObject VFX = Instantiate(impactVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(VFX, 1);
    }
}
