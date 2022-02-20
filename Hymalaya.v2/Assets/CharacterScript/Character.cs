using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Wrapper : MonoBehaviour
{
    public Transform bikeTracker;
    public Transform rigTracker;
    public Rigidbody bikeBody;
    public Rigidbody rigBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigTracker = GameObject.Find("XR Origin/Camera Offset/Main Camera").GetComponent<Transform>();
        bikeTracker = GameObject.Find("XR Origin/Camera Offset/Main Camera/bike").GetComponent<Transform>();
        bikeTracker.eulerAngles  = new Vector3(0, -rigTracker.eulerAngles.y,  0); 
    }
}
