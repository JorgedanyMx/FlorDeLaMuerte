using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource environmentAudioSource;
    [SerializeField] AudioSource environmentAudioSource1;
    [SerializeField] AudioSource environmentAudioSource2;
    [SerializeField] AudioSource environmentAudioSource3;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource voiceAudioSource;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioClip[] environmentSounds;
    [SerializeField] AudioClip[] dialogSounds;
    [SerializeField] GameEvent dialogEndEvent;
    AudioClip nextTrack;
    int dialogIndex = 0;
    void Awake()
    {
        StartEnvironmentSoundEnvironmentSounds();
    }
    public void JumpSound()
    {
        SFX.PlayOneShot(sounds[0]); 
    }
    public void PrimerMovimiento()
    {
        StartCoroutine(FadeInVolume(5f, environmentAudioSource1));
    }
    public void SegundoMovimiento()
    {
        StartCoroutine(FadeInVolume(5f, environmentAudioSource2));
    }
    public void TercerMovimiento()
    {
        StartCoroutine(FadeInVolume(5f, environmentAudioSource3));
    }

    public void DialogSFX()
    {
        voiceAudioSource.Stop();
        voiceAudioSource.PlayOneShot(dialogSounds[dialogIndex]); 
        dialogIndex++;
        StartCoroutine(WaitForDialogEnd());
        
    }
    private IEnumerator  WaitForDialogEnd()
    {
        yield return new WaitForSeconds(dialogSounds[dialogIndex-1].length);
        dialogEndEvent.Raise();

    }
    void StartEnvironmentSoundEnvironmentSounds()
    {
        environmentAudioSource.clip = environmentSounds[1];
        environmentAudioSource1.clip = environmentSounds[2];
        environmentAudioSource2.clip = environmentSounds[3];
        environmentAudioSource3.clip = environmentSounds[4];
        environmentAudioSource1.volume = 0f;
        environmentAudioSource2.volume = 0f;
        environmentAudioSource3.volume = 0f;
        environmentAudioSource.Play();
        environmentAudioSource1.Play();
        environmentAudioSource2.Play();
        environmentAudioSource3.Play();
    }
    IEnumerator FadeInVolume(float duration,AudioSource tmpAudioSource)
    {
        float currentTime = 0f; // Contador de tiempo

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime; // Incrementa el tiempo transcurrido
            tmpAudioSource.volume = Mathf.Lerp(0f, 1f, currentTime / duration); // Ajusta el volumen
            yield return null; // Espera un frame antes de continuar
        }
        // Asegúrate de que el volumen llegue exactamente a 1
        tmpAudioSource.volume = 1f;
    }
    void StopEnvironmentAudios()
    {
        environmentAudioSource.Stop();
        environmentAudioSource1.Stop();
        environmentAudioSource2.Stop();
        environmentAudioSource3.Stop();
    }
    public void Finale()
    {
        StopEnvironmentAudios();
        environmentAudioSource.clip = environmentAudioSource3.clip = environmentSounds[5];
        environmentAudioSource.Play();
    }
    public void BackToCheckpoint()
    {
        SFX.PlayOneShot(sounds[1]);
    }
    public void StopSFX()
    {
        SFX.Stop();
    }
}
