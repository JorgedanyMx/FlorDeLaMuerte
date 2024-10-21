using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueElevador : MonoBehaviour
{
    public float speed=5f;
    [SerializeField] GameObject Punto1;
    [SerializeField] GameObject Punto2;
    bloqueState bState = bloqueState.bloqueA;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(Punto1.GetComponent<SpriteRenderer>()!=null)
            Punto1.GetComponent<SpriteRenderer>().enabled = false;
        if (Punto2.GetComponent<SpriteRenderer>() != null)
            Punto2.GetComponent<SpriteRenderer>().enabled = false;
        bState = bloqueState.bloqueA;
        transform.position = Punto1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bState == bloqueState.bloqueA || bState == bloqueState.bloqueB) return;
        MoveBloque();
    }
    void MoveBloque()
    {
        if (bState == bloqueState.movingToA)
        {
            transform.position = Vector3.MoveTowards(transform.position, Punto1.transform.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, Punto1.transform.position);
            if (distance<.1f)
            {
                bState = bloqueState.bloqueA;
            }
        }
        if (bState == bloqueState.movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, Punto2.transform.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, Punto2.transform.position);
            if (distance < .1f)
            {
                bState = bloqueState.bloqueB;
            }
        }
        Debug.DrawLine(Punto1.transform.position, Punto2.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (bState == bloqueState.bloqueA)
                bState = bloqueState.movingToB;
            if (bState == bloqueState.bloqueB)
                bState = bloqueState.movingToA;
        }
    }
    enum bloqueState
    {
        bloqueA,
        bloqueB,
        movingToA,
        movingToB,
    }
}
