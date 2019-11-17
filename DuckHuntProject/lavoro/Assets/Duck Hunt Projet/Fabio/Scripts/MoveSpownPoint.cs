using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSpownPoint : MonoBehaviour
{
    public float velocita = 2;
    public float min = 39, max = 46;



        void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
    }
}
