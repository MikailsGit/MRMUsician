using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float rotationSpeedChangeSensitivity = 1.0f;  

    void Update()
    {
        Vector2 rightThumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float leftVertical = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        rotationSpeed += leftVertical * rotationSpeedChangeSensitivity;
        rotationSpeed = Mathf.Clamp(rotationSpeed, 1f, 100f);

        Vector3 rotation = transform.localEulerAngles;
        rotation.y += rightThumbstick.x * rotationSpeed * Time.deltaTime;
        rotation.x -= rightThumbstick.y * rotationSpeed * Time.deltaTime;

        transform.localEulerAngles = rotation;
    }
}





/*
public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private InputDevice rightHandController;

    private void Start()
    {
        GetDeviceCharacteristics();
    }

    private void GetDeviceCharacteristics()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightHandCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightHandCharacteristics, devices);

        if (devices.Count > 0)
        {
            rightHandController = devices[0];
        }
    }

    void Update()
    {
        if (rightHandController.isValid)
        {
            if (rightHandController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue))
            {
                transform.Rotate(Vector3.up, primary2DAxisValue.x * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            GetDeviceCharacteristics();
        }
    }
}
*/