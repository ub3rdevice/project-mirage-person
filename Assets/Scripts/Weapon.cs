using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPVCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float timeBetweenShots = .5f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject impactVFX;
    [SerializeField] Ammo ammoSlot;

    bool canShoot = true;
    

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot ==true)
        {
            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot()
    {
        canShoot = false;

        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleflashVFX();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
