using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public GameObject canvasPlay;
    public GameObject canvasWin;
    public Mirino mirino;
    public GlobalVariableManager GVM;


    public void Awake()
    {
        //mirino = GameObject.Find("Mirino").GetComponent<Mirino>();
    }

    public void BulletCheck(int bullets)
    {
        Debug.Log("faccio il check dei proiettili");
        if (mirino.score>=100)
        {
            GVM._SCORE = mirino.score;
            GVM._BULLETS = mirino.bullets;
            canvasPlay.SetActive(false);
            canvasWin.SetActive(true);
        }
        else if (bullets <=0)
        {
            GVM._SCORE = mirino.score;
            GVM._BULLETS = mirino.bullets;
            canvasPlay.SetActive(false);
            canvasWin.SetActive(true);
        }

    }

    public void DuckCheck()
    {
        //Debug.Log("faccio il check delle papere");
        //if (mirino.numeroPapere <=0 && mirino.score >= 100)
        //{
        //    canvasPlay.SetActive(false);
        //    canvasWin.SetActive(true);
        //    mirino.gameObject.SetActive(false);
        //}
        //else if (mirino.numeroPapere <=0 && mirino.score < 100)
        //{
        //    canvasPlay.SetActive(false);
        //    canvasLose.SetActive(true);
        //    mirino.gameObject.SetActive(false);
        //}
    }
}

