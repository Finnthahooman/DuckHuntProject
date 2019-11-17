using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public int vita = 2;
    public TIPI_DI_PAPERE tipo;
    private DuckHead head;
    public LevelManager levelManager;
    public Mirino mirino;
    public Animator anim;

    public enum TIPI_DI_PAPERE
    {
        RIGHT_DUCK,
        WRONG_DUCK,
        BONUS_DUCK
    }

    public void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
        if ( anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
        mirino = FindObjectOfType<Mirino>();
        head = GetComponentInChildren<DuckHead>();
        if ( head != null )
        {
            head.owner = this;
        }
        
    }
    public void Danneggia(int damage)
    {
        vita -= damage;
        anim.SetTrigger("Presa");

        if (vita <= 0)           
        {
           
            anim.SetTrigger("Morta");
            Destroy(this.gameObject.GetComponent<Collider>());
            if (head != null)
            {
                Destroy(head.GetComponent<Collider>());

            }


            if (tipo == TIPI_DI_PAPERE.RIGHT_DUCK)
            {
                mirino.numeroPapere -= 1;
                levelManager.DuckCheck();

            }
            

        }
    }
   
}
