using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource environmentAudio;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip[] sounds;
    public void JumpSound()
    {
        SFX.PlayOneShot(sounds[0]); 
    }
}
