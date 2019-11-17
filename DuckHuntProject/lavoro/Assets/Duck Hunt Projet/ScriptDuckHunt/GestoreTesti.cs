using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestoreTesti : MonoBehaviour
{
    public Text nProiettili;
    public Text score;
    public Mirino mirino;
    // Start is called before the first frame update
    void Awake()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        nProiettili.text = "" + mirino.bullets + "";
        score.text = "" + Mirino.score + "";
    }
}
