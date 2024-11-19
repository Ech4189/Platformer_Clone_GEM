using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject TeleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = TeleportPoint.transform.position;
    }

}


  

