using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource environmentAudioSource;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioClip[] environmentSounds;
    public void JumpSound()
    {
        SFX.PlayOneShot(sounds[0]); 
    }
    private void Update()
    {
        if (!environmentAudioSource.isPlaying)
        {

        }
    }
}
