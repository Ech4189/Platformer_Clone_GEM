using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject TeleportPoint;
    public GameObject TeleportPoint1b;
    public GameObject TeleportPoint2;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = TeleportPoint.transform.position;
        other.transform.position = TeleportPoint1b.transform.position;
        other.transform.position = TeleportPoint2.transform.position;
    }

}


  

