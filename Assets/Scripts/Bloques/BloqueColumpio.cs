using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueColumpio : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        //anim.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Light"))
        {
            anim.SetTrigger("PlayColumpio");
        }
    }
}
