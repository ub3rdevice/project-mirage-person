using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;

    void Update()
    {
        TurnOnFlashLight();
    }

    public void TurnOnFlashLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            bool currentState = flashlight.activeSelf;

            currentState = !currentState;

            flashlight.SetActive(currentState);   
        }
    }
}
