using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPVCamera;
    [SerializeField] RigidbodyFirstPersonController fpscontroller;
    [SerializeField] float zoomedInFOV = 25f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInSens = 0.75f;
    [SerializeField] float zoomedOutSens = 2f;

    bool zoomedInToggle = false;

    void OnDisable()
    {
       ZoomOut(); 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();

            }
            else
            {
                ZoomOut();
            }
        }
    }

    void ZoomIn()
    {
        zoomedInToggle = true;
        FPVCamera.fieldOfView = zoomedInFOV;
        fpscontroller.mouseLook.XSensitivity = zoomedInSens;
        fpscontroller.mouseLook.YSensitivity = zoomedInSens;
    }

    void ZoomOut()
    {
        zoomedInToggle = false;
        FPVCamera.fieldOfView = zoomedOutFOV;
        fpscontroller.mouseLook.XSensitivity = zoomedOutSens;
        fpscontroller.mouseLook.YSensitivity = zoomedOutSens;
    }
}
