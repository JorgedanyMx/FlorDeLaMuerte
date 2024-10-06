using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueAtraido : MonoBehaviour
{
    public float distanciaMov = 5f;  // Distancia que se mover� el bloque hacia "Light"
    [SerializeField] Transform target;
    [SerializeField] float waitPosTime=.5f;
    private Vector3 posicionInicial;  // Guarda la posici�n inicial del bloque
    private bool atraido = false;  // Verifica si est� siendo atra�do por "Light"
    void Start()
    {
        
        // Almacena la posici�n inicial del bloque al empezar
        posicionInicial = transform.position;
        if (target == null)
        {
            Debug.LogError("Hola! te falt� agregar el a donde se va a mover el bloque");
        }
        target.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        // Si est� siendo atra�do, mueve el bloque hacia "Light"
        if (atraido)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, distanciaMov * Time.deltaTime); // Mueve el bloque hacia el objeto "Light" a una distancia espec�fica
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, distanciaMov * Time.deltaTime);   // Si no est� siendo atra�do, regresa el bloque a su posici�n inicial
        }
        Debug.DrawLine(posicionInicial, target.position, Color.red);
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
