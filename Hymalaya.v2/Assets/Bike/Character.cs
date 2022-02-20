using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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
        bikeTracker = GameObject.Find("bike").GetComponent<Transform>();
        bikeTracker.position = new Vector3(rigTracker.position.x, (float) (rigTracker.position.y - 0.5), (float ) (rigTracker.position.z + 0.7)); 
        bikeTracker.eulerAngles  = new Vector3(0, rigTracker.eulerAngles.y,  0); 


    }
}
