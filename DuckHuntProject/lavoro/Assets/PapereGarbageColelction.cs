using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapereGarbageColelction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "duck")
        {
            Destroy(other.gameObject);
        }

    }
}
