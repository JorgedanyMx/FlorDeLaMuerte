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
        Color spcolor = new Color(sp.color.r, sp.color.g, sp.color.b, 0.3f);
        sp.material.SetColor("_Color", spcolor);
    }
    void SetBasicColor()
    {
        sp.material.SetColor("_Color", colorInitial);
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
            SetBasicColor();
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
