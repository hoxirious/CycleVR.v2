using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
 
public class PlayerMovementControl : MonoBehaviour
{
    private InputDevice _device_leftController;
    private InputDevice _device_rightController;
 
    private Vector2 _inputAxis_leftController;
    private Vector2 _inputAxis_rightController;
 
    private float _inputTrigger_leftController;
    private float _inputTrigger_rightController;
 
    private bool _inputPrimary_leftController;
    private bool _inputPrimary_rightController;
 
    private float _inputPrimary_leftController_ReleaseTime;
    private float _inputPrimary_rightController_ReleaseTime;
 
    private float _inputPrimary_leftController_PressTime;
    private float _inputPrimary_rightController_PressTime;
 
    private bool _inputSecondary_leftController;
    private bool _inputSecondary_rightController;
 
    private Camera _camera;
 
       void Start()
    {
        _device_leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        _device_rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        _camera = GetComponent<XROrigin>().Camera;
 
    }
 
    void getInput()
    {
        _device_leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis_leftController); // left stick
        _device_rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis_rightController); //right stick
 
        _device_leftController.TryGetFeatureValue(CommonUsages.trigger, out _inputTrigger_leftController); // left trigger
        _device_rightController.TryGetFeatureValue(CommonUsages.trigger, out _inputTrigger_rightController); //right trigger
 
        _device_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out _inputPrimary_leftController); // X Button
        _device_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out _inputPrimary_rightController);// A Button
 
        // releaseTime
        if (_inputPrimary_leftController)
        {
            _inputPrimary_leftController_ReleaseTime = 0f;
        }
        else
        {
            _inputPrimary_leftController_ReleaseTime = Mathf.Min(_inputPrimary_leftController_ReleaseTime + Time.deltaTime, 1200f);
        }
 
        if (_inputPrimary_rightController)
        {
            _inputPrimary_rightController_ReleaseTime = 0f;
        }
        else
        {
            _inputPrimary_rightController_ReleaseTime = Mathf.Min(_inputPrimary_rightController_ReleaseTime + Time.deltaTime, 1200f);
        }
 
        // pressTime
        if (_inputPrimary_leftController)
        {
            _inputPrimary_leftController_PressTime = Mathf.Min(_inputPrimary_leftController_PressTime + Time.deltaTime, 1200f);
        }
        else
        {
            _inputPrimary_leftController_PressTime = 0f;
        }
 
        if (_inputPrimary_rightController)
        {
            _inputPrimary_rightController_PressTime = Mathf.Min(_inputPrimary_rightController_PressTime + Time.deltaTime, 1200f);
        }
        else
        {
            _inputPrimary_rightController_PressTime = 0f;
        }
 
        _device_leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out _inputSecondary_leftController); // Y Button
        _device_rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out _inputSecondary_rightController); //B Button
 
    }
    void Update(){
        getInput();
        Debug.Log(_inputAxis_leftController);
        Debug.Log(_inputTrigger_leftController);
        // if (_inputAxis_leftController){
        //     Debug.Log("joystick left");
        // }
    }
}
 