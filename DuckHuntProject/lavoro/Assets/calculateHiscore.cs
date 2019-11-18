using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class calculateHiscore : MonoBehaviour
{
    public TMP_Text textValues, hiScore;
    public AudioSource aS;
    public AudioClip pointCountingLoop,loopLento,LoopLentissimo;
    public Animator anim;
    public GlobalVariableManager GVM;
    public GameObject feC;
    public RandomSpawn RS;
    string nuovoTesto;
    private void Awake()
    {
        RS.StopCoroutine("SpawnaPeraACaso");

        Cursor.visible = true;

        if (aS != null)
        {

        }
        else { aS = GetComponent<AudioSource>(); }

        nuovoTesto = "Score:<color=#11ee22>" + GVM._SCORE + "<color=#ffffff> Bullets:<color=#ee1111>" + GVM._BULLETS + " ";
    }

    public void AvviaCorutineScrittura()
    {
        StartCoroutine("SettaScores");
    }
    public void AvviaCorutinePunteggio()
    {
        StartCoroutine("CalcolaPunteggio");
    }
    public IEnumerator SettaScores()
    {
        int i = 0;

        while (i < nuovoTesto.Length)
        {

            if (nuovoTesto.Substring(i, 1) == "<")
            {
                i += 15;
                textValues.text = nuovoTesto.Substring(0, i);
                yield return new WaitForSeconds(0.1f);
                //i++;
            }
            else
            {
                textValues.text = nuovoTesto.Substring(0, i);
                yield return new WaitForSeconds(0.01f);
                i++;
            }

        }

        anim.SetBool("CalcoloFinito",true);

        StopCoroutine("SettaScores");

    }

    public IEnumerator CalcolaPunteggio()
    {
        float intHiScore;

        if (GVM._BULLETS == 0)
        {
            intHiScore = GVM._SCORE;
        }
        else
        {
            intHiScore = GVM._SCORE * GVM._BULLETS;
        }

        aS.clip = pointCountingLoop;
        aS.loop = true;
        aS.Play();

        while (hiScore.text != intHiScore.ToString())
        {
            float txtVal = float.Parse(hiScore.text);

            
            

            if (txtVal < ((3.5f/4) * intHiScore))
            {
                txtVal += ((1f/10)*intHiScore);
                
            }
            else if (txtVal < ((3.9f / 4) * intHiScore))
            {
                txtVal += ((1f / 100) * intHiScore);
                
            }
            else if (txtVal < ((3.99f / 4) * intHiScore))
            {
                txtVal += ((1f / 1000) * intHiScore);
                
            }
            else if (txtVal < ((3.999f / 4) * intHiScore))
            {
                aS.clip = loopLento;
                aS.Play();
                txtVal += 1;
            }
            else
            {
                aS.clip = LoopLentissimo;
                aS.Play();
                txtVal += 1;
                yield return new WaitForSeconds(0.2f);
            }


            hiScore.text = Mathf.Ceil(txtVal).ToString();

            yield return new WaitForSeconds(0.1f);
            //Debug.Log(Mathf.Lerp(txtVal, intHiScore / 2, -0.5f) * -1);


        }

        aS.loop = false;
        aS.Stop();

        anim.SetBool("AvviaFanfara", true);

        StopCoroutine("CalcolaPunteggio");

    }

    public void FanfaraEConfetti()
    {

        feC.SetActive(true);

    }

    public void FaiUnSuono(AudioClip c)
    {

        aS.clip = c;
        aS.Play();

    }
}
