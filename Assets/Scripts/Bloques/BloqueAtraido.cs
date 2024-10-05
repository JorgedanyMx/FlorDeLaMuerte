using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueAtraido : MonoBehaviour
{
    public float distanciaMov = 5f;  // Distancia que se moverá el bloque hacia "Light"
    [SerializeField] Transform target;
    [SerializeField] float waitPosTime=.5f;
    private Vector3 posicionInicial;  // Guarda la posición inicial del bloque
    private bool atraido = false;  // Verifica si está siendo atraído por "Light"
    void Start()
    {
        
        // Almacena la posición inicial del bloque al empezar
        posicionInicial = transform.position;
        if (target == null)
        {
            Debug.LogError("Hola! te faltó agregar el a donde se va a mover el bloque");
        }
        target.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        // Si está siendo atraído, mueve el bloque hacia "Light"
        if (atraido)
        {
            // Mueve el bloque hacia el objeto "Light" a una distancia específica
            Debug.DrawLine(posicionInicial, target.position,Color.red);
            transform.position = Vector3.MoveTowards(transform.position, target.position, distanciaMov * Time.deltaTime);
        }
        else
        {
            // Si no está siendo atraído, regresa el bloque a su posición inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, distanciaMov * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            atraido = true;
            Debug.Log("Atraido");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            StartCoroutine("BacktoStartPosition");
            Debug.Log("Atraidont");
        }
    }
    IEnumerator BacktoStartPosition()
    {
        yield return new WaitForSeconds(waitPosTime);
        atraido = false;
    }
}
