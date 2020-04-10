using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;

    public GameObject go;
    public GameObject vm;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            //Debug.Log("overalapping");
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0.0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0.0f, rotationDiff, 0.0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {

            //Debug.Log(other.gameObject.name);
            playerIsOverlapping = true;

            if (transform.gameObject.name == "ColliderPlane1")
            {
                //Debug.Log(transform.gameObject.name);
                PortalCamera.enterPortal = false;
                go.SetActive(true);
                vm.SetActive(true);
            } else if (transform.gameObject.name == "ColliderPlane2")
            {
                PortalCamera.enterPortal = true;
                go.SetActive(false);
                vm.SetActive(false);
            }
            

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            //PortalCamera.enterPortal = false;
        }
    }
}
