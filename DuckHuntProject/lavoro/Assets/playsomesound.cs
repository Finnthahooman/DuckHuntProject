using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsomesound : MonoBehaviour
{

    public AudioSource aS;

    private void Awake()
    {
        if (aS != null)
        {

        }
        else { aS = GetComponent<AudioSource>(); }
        
    }
    public void PlayAudio(AudioClip clip)
    {
        aS.clip = clip;
        aS.Play();
    }
}
