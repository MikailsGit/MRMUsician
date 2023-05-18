using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class RotationSpeedController : MonoBehaviour
{
    public Slider rotationSpeedSlider;
    public RotateCamera rotateScript;


    void Update()
    {

        rotationSpeedSlider.value = rotateScript.rotationSpeed;

        
    }
}
