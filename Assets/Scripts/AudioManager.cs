using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource environmentAudioSource;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioClip[] environmentSounds;
    AudioClip nextTrack;
    private void Start()
    {
        environmentAudioSource.loop = false;
        environmentAudioSource.PlayOneShot(environmentSounds[0]);
        nextTrack = environmentSounds[0];
    }
    public void JumpSound()
    {
        SFX.PlayOneShot(sounds[0]); 
    }
    private void Update()
    {
        if (!environmentAudioSource.isPlaying)
        {
            environmentAudioSource.PlayOneShot(nextTrack);
            Debug.Log("Playing"+ nextTrack.name);
        }
    }
    void NextEnvironmentSound(AudioClip clipEnvironment)
    {
        nextTrack = clipEnvironment;
    }
    public void PrologoMovimiento()
    {
        nextTrack = environmentSounds[1];
    }
    public void PrimerMovimiento()
    {
        nextTrack = environmentSounds[2];
    }
    public void SegundoMovimiento()
    {
        nextTrack = environmentSounds[3];
    }
    public void TercerMovimiento()
    {
        nextTrack = environmentSounds[4];
    }
}
