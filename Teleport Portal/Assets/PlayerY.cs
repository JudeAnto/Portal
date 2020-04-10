using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerY : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 3.07f, transform.position.z);
    }
}
