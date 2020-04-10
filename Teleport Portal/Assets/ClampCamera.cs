using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampCamera : MonoBehaviour
{
    //public Transform target;
    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, 0.0f, 29.0f),
            Mathf.Clamp(transform.position.y, 0.0f, 10.5f),
            Mathf.Clamp(transform.position.z, -29.0f, 0.0f)
            );
    }
}
