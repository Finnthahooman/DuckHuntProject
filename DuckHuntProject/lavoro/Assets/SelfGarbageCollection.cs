using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfGarbageCollection : MonoBehaviour
{
    private void Update()
    {
        if (transform.localPosition.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.parent.tag == "BOUND")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    
}
