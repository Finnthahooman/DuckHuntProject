using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class calculateHiscore : MonoBehaviour
{
    public TMP_Text textValues, hiScore;
    public AudioClip[] aClips;
    public AudioSource aS;
    public Animator anim;
    public GlobalVariableManager GVM;
    string nuovoTesto;
    private void Awake()
    {
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

        Debug.Log((3f / 4) * intHiScore);
        Debug.Log((2f / 4) * intHiScore);
        Debug.Log((1f / 4) * intHiScore);
        Debug.Log((0.5f / 4) * intHiScore);
        Debug.Log((0.25f / 4) * intHiScore);
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
            else if (txtVal < ((3.97f / 4) * intHiScore))
            {
                txtVal += ((1f / 1000) * intHiScore);
                
            }
            else if (txtVal < ((3.99f / 4) * intHiScore))
            {
                txtVal += 1;
            }
            else
            {
                txtVal += 1;
                yield return new WaitForSeconds(0.2f);
            }


            hiScore.text = Mathf.Ceil(txtVal).ToString();

            yield return new WaitForSeconds(0.1f);
            //Debug.Log(Mathf.Lerp(txtVal, intHiScore / 2, -0.5f) * -1);


        }
       
    }
}
