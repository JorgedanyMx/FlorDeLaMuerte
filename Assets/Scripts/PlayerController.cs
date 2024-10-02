using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject brillo;  // GameObject para Brillo
    public float velocidadMovimiento = 5f;  // Velocidad de movimiento del jugador
    public float fuerzaSalto = 7f;  // Fuerza de salto
    public float tiempoMaximoEncendido = 5f;  // Tiempo máximo que puede estar encendida la luz
    public float cooldownDuracion = 3f;  // Duración del cooldown para volver a encender la luz
    public bool luzActiva = false;  // Para controlar si la luz está activada
    public LayerMask capaGround;  // Capa para detectar el suelo

    [SerializeField] private float contadorTiempo = 0f;  // Contador para el tiempo que la luz está activada    

    private bool puedeSaltarDoble = false;  // Controla si se puede hacer el segundo salto
    [SerializeField] private bool estaEnSuelo = false;  // Verifica si el jugador está en el suelo    
    private bool enCooldown = false;  // Controla si está en cooldown
    private float longitudRaycast = 1f;  // Longitud del Raycast
    

    private Rigidbody2D rb;
    void Awake()
    {
        // Asigna el tag "Player"
        gameObject.tag = "Player";
        rb = GetComponent<Rigidbody2D>();
        brillo.SetActive(false);
    }
    void Update()
    {
        LightControl();
        playerMovement();
        DetectarSuelo();
    }
    void DetectarSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaGround);
        if (hit.collider != null)
        {
            estaEnSuelo = true;
        }
        else
        {
            estaEnSuelo = false;
            Debug.Log("no detecta suelo");
        }
        Debug.DrawRay(transform.position, Vector2.down * longitudRaycast, Color.red);
    }
    public bool EstaEnSuelo()
    {
        return estaEnSuelo;
    }
    void playerMovement()
    {
        // Movimiento del jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);

        // Saltar y doble salto
        if (Input.GetButtonDown("Jump"))
        {
            if (estaEnSuelo)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                puedeSaltarDoble = true;
            }
            else if (puedeSaltarDoble)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                puedeSaltarDoble = false;  // Desactiva el doble salto después de usarlo
            }
        }
    }
    void LightControl()
    {
        // Activar/desactivar el GameObject "Brillo" con la tecla Espacio
        if (Input.GetButtonDown("Light") && !enCooldown)
        {
            luzActiva = true;
            brillo.SetActive(true);
        }
        if (Input.GetButtonUp("Light") && !enCooldown)
        {
            luzActiva = false;
            brillo.SetActive(false);
        }
        if (luzActiva)
        {
            contadorTiempo += Time.deltaTime;
            if (contadorTiempo >= tiempoMaximoEncendido)// Si el tiempo máximo se ha alcanzado, desactiva la luz y empieza el cooldown
            {
                DesactivarLuzYEmpezarCooldown();
            }
        }
    }
    void DesactivarLuzYEmpezarCooldown()
    {
        contadorTiempo = 0;
        luzActiva = false;
        brillo.SetActive(false);
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {
        enCooldown = true;  // Marca que está en cooldown
        yield return new WaitForSeconds(cooldownDuracion);  // Espera el tiempo del cooldown
        enCooldown = false;  // Cooldown completado, puede activarse de nuevo
    }
}
