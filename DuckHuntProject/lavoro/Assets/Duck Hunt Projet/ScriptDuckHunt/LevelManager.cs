using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public GameObject canvasPlay;
    public GameObject canvasWin;
    public GameObject canvasPausa;
    public Mirino mirino;
    public GlobalVariableManager GVM;
    public bool isPaused = false;
    private void Update()
    {
        if (canvasWin.activeSelf)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                isPaused = !isPaused;
                if (isPaused)
                {
                    Cursor.visible = true;
                    canvasPlay.SetActive(false);
                    canvasPausa.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    Resume();
                }

            }
        }

    }
    public void Resume()
    {
        isPaused = false;
        Cursor.visible = false; 
        canvasPlay.SetActive(true);
        canvasPausa.SetActive(false);
        Time.timeScale = 1f;

    }
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

