using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquePesado : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}