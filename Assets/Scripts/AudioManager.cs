using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource environmentAudio;
    private void Start()
    {
        environmentAudio = GetComponent<AudioSource>();
    }
}
