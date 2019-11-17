using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public GameObject canvasPlay;
    public GameObject canvasWin;
    public GameObject canvasLose;
    public Mirino mirino;


    public void Awake()
    {
        mirino = FindObjectOfType<Mirino>();
    }

    public void BulletCheck(int bullets)
    {
        Debug.Log("faccio il check dei proiettili");
        if (bullets<=0 && Mirino.score>=100)
        {
            canvasPlay.SetActive(false);
            canvasWin.SetActive(true);
        }
        else if (bullets <=0 && Mirino.score<100)
        {
            canvasPlay.SetActive(false);
            canvasLose.SetActive(true);
        }
    }

    public void DuckCheck()
    {
        Debug.Log("faccio il check delle papere");
        if (mirino.numeroPapere <=0 && Mirino.score >= 100)
        {
            canvasPlay.SetActive(false);
            canvasWin.SetActive(true);
            mirino.gameObject.SetActive(false);
        }
        else if (mirino.numeroPapere <=0 && Mirino.score < 100)
        {
            canvasPlay.SetActive(false);
            canvasLose.SetActive(true);
            mirino.gameObject.SetActive(false);
        }
    }
}

