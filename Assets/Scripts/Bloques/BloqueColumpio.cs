using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueColumpio : MonoBehaviour
{
    Animator anim;
    AudioSource audioSource;
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        audioSource = transform.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Light"))
        {
            anim.SetTrigger("PlayColumpio");
            audioSource.Play();
        }
    }
}
