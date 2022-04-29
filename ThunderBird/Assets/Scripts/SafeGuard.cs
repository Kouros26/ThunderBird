using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGuard : MonoBehaviour
{
    public GameObject safePoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup" || other.tag == "Player")
        {
            other.transform.position = safePoint.transform.position;
        }
    }
}
