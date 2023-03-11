using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightToggle : MonoBehaviour
{
    bool Flashlight = false;
    [SerializeField] GameObject FlashObj;
   
    

    public void ToggleFlashLight(bool toggle) 
    {
        Flashlight = toggle;
        FlashObj.SetActive(Flashlight);
    }

    public bool GetFlashToggleVal() 
    {
        return Flashlight;
    }



}
