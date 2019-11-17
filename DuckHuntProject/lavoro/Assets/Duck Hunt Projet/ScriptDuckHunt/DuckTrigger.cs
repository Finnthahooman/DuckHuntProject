using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTrigger : MonoBehaviour
{
    public Mirino mirino;
    public LevelManager levelManager;

    public void Awake()
    {
        mirino = FindObjectOfType<Mirino>();
    }


    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Duck duck = other.gameObject.GetComponent<Duck>();
        if (duck != null )
        {
            if (duck.tipo == Duck.TIPI_DI_PAPERE.RIGHT_DUCK)
            {
                mirino.numeroPapere -= 1;
                levelManager.DuckCheck();

            }     
        }
    }
}
