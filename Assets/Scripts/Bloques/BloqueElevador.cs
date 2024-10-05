using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueElevador : MonoBehaviour
{
    public GameObject bloque;
    [SerializeField] GameObject Punto1;
    [SerializeField] GameObject Punto2;
    bloqueState bState = bloqueState.bloqueA;
    // Start is called before the first frame update
    void Start()
    {
        bloque.transform.position = Punto1.transform.position;
        bState = bloqueState.bloqueA;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    enum bloqueState
    {
        bloqueA,
        bloqueB,
        moving
    }
}
