using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquePesado : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource sfxSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfxSource = GetComponent<AudioSource>();
        //rb.bodyType = RigidbodyType2D.Static;
        rb.mass = 1000;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            //rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 10;
            rb.freezeRotation = false;
            sfxSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            //rb.bodyType = RigidbodyType2D.Static;
            rb.mass = 1000;
            rb.freezeRotation = true;
            sfxSource.Stop();
        }
    }
}
