using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    
    public GameEvent lightEventv1;
    [SerializeField]AudioClip audioClip;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
            lightEventv1.Raise();
            Destroy(transform.gameObject, 1f);
        }
    }
}
