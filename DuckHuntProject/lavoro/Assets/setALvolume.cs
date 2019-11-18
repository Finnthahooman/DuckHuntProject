using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setALvolume : MonoBehaviour
{
    public void setVolume(float volume)
    {

        AudioListener.volume = volume;

    }
}

