using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class LeftJoystick : MonoBehaviour
{
public XRNode inputSource;
public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButtonTrigger;
public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButtonRight;
public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButtonLeft;
public float threshold = 0.1f;

public Transform movementSource;

public GameObject XRO;

private bool isMoving = false;
private List<Vector3> positionList = new List<Vector3>();
public float beginSpot;
public float previousSpot;
public float currentSpot;
private Transform xrTransform;
public Vector3 forward;
public Vector3 nose; 
public Vector3 currPos; 
    
    // Start is called before the first frame update
    void Start()
    {
        xrTransform = XRO.GetComponent<Transform>();
        nose = GameObject.Find("Camera Offset/Main Camera").GetComponent<Transform>().GetChild(0).position;
        currPos = GameObject.Find("Camera Offset").GetComponent<Transform>().GetChild(0).position;
        // nose = Find("bikenose")GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        nose = GameObject.Find("Camera Offset/Main Camera").GetComponent<Transform>().GetChild(0).position;
        currPos = GameObject.Find("Camera Offset").GetComponent<Transform>().GetChild(0).position;
        forward = Vector3.Normalize(nose - currPos);
        // nose = GameObject.Find("bikenose").GetComponent<Transform>().position;
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButtonTrigger, out bool isPressedTrigger, threshold );
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButtonRight, out bool isPressedRight, threshold );
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButtonLeft, out bool isPressedLeft, threshold );
    

        //Start Movement
        if(!isMoving && isPressedTrigger){
            //Debug.Log("Start moving");
            isMoving = true;
            beginSpot = movementSource.position.y;
            currentSpot = beginSpot;
            previousSpot = beginSpot;
            //positionList.Add(movementSource.position);
        }
        //Update movement
        else if(isMoving){
            // Debug.Log(movementSource.position.y);
            currentSpot = movementSource.position.y;
            //Debug.Log("Update Movement");
            //positionList.Add(movementSource.position);

            // previousSpot = currentSpot;
            // currentSpot = movementSource.position.y;

            //move
            if(isPressedRight){
                xrTransform.Rotate(0.0f, Mathf.Deg2Rad * 25, 0.0f, Space.Self);
                // xrTransform.eulerAngles = new Vector3(xrTransform.eulerAngles.x, xrTransform.eulerAngles.y+1, xrTransform.eulerAngles.z);
                isPressedRight = false;
                //Debug.Log(isMoving);
            }
            if(isPressedLeft){
                xrTransform.Rotate(0.0f, Mathf.Deg2Rad * -25, 0.0f, Space.Self);
                // xrTransform.eulerAngles = new Vector3(xrTransform.eulerAngles.x, xrTransform.eulerAngles.y-1, xrTransform.eulerAngles.z);
                isPressedLeft = false;
                //Debug.Log(isMoving);
            }

            if((currentSpot - previousSpot > 0.1 || currentSpot - previousSpot < -0.1)){
                // Debug.Log("move");
                // Vector3 dir = Vector3.Normalize(nose - xrTransform.position);
                xrTransform.position += 150 * new Vector3(forward.x, 0, forward.z) * Time.deltaTime;
                previousSpot = currentSpot;
                // Move the object upward in world space 1 unit/second.
                //xrTransform.Translate(Vector3.forward * 100*  Time.deltaTime);
            }
            // previousSpot = currentSpot;
            // if(Vector3.Distance(movementSource.position, positionList[0]) == 0){
            //     positionList.Clear();

            // }
        }
        //End
        // else if(isMoving && isPressedTrigger){
        //     //Debug.Log("End Movement");
        //     isMoving = false;
        //     isPressedTrigger = false;
        //     positionList.Clear();
        // }
    }

}
