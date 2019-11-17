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
    public AudioClip morte,colpita;
    public AudioSource As;

    public enum TIPI_DI_PAPERE
    {
        RIGHT_DUCK,
        WRONG_DUCK,
        BONUS_DUCK
    }

    public void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        anim = GetComponent<Animator>();
        if ( anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
        mirino = GameObject.Find("Mirino").GetComponent<Mirino>();
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

        As.clip = colpita;
        As.Play();

        if (vita <= 0)           
        {
            As.clip = morte;
            As.Play();
            anim.SetTrigger("Morta");
            Destroy(this.gameObject.GetComponent<Collider>());
            if (head != null)
            {
                Destroy(head.GetComponent<Collider>());

            }
            if (tipo == TIPI_DI_PAPERE.RIGHT_DUCK)
            {
                mirino.numeroPapere -= 1;
                //levelManager.DuckCheck();

            }
        }
    }
   
}
