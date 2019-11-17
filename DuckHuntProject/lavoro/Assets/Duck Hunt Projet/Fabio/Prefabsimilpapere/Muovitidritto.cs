using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muovitidritto : MonoBehaviour
{

    public float velocita = 5;
    public float velocitaCaduta = 5;
    public Vector3 rOffset;

    private void Update()
    {
        int SDuck = GetComponent<Duck>().vita;

        transform.localPosition += transform.forward * velocita * Time.deltaTime;

        if (SDuck > 0)
        {

            transform.localPosition += transform.forward * velocita * Time.deltaTime;

        }
        else
        {

            this.transform.LookAt(transform.position, -transform.up);
            this.transform.eulerAngles = rOffset;
            transform.localPosition += new Vector3(0, -1 * velocitaCaduta * Time.deltaTime, 0);

        }
    }
        
}
