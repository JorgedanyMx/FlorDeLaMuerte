using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueInvisible : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    BoxCollider2D myCollider;
    private Color colorInitial;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        colorInitial = sp.color;
    }
    void SetInvisibleColor()
    {
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0.1f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            SetInvisibleColor();
            myCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            sp.color = colorInitial;
            myCollider.isTrigger = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Light"))
        {
            sp.color = colorInitial;
            myCollider.isTrigger = false;
        }
    }
}
