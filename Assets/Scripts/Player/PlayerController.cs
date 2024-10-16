using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject brillo;  // GameObject para Brillo
    public float velocidadMovimiento = 5f;  // Velocidad de movimiento del jugador
    public float fuerzaSalto = 7f;  // Fuerza de salto
    public float tiempoMaximoEncendido = 5f;  // Tiempo máximo que puede estar encendida la luz
    public float cooldownDuracion = 3f;  // Duración del cooldown para volver a encender la luz
    public float cooldownDuracionEspera = 1f;  // Duración del cooldown si no esta
    public bool luzActiva = false;  // Para controlar si la luz está activada
    public LayerMask capaGround;  // Capa para detectar el suelo
    [SerializeField] private bool estaEnSuelo = false;  // Verifica si el jugador está en el suelo    
    [SerializeField] private float contadorTiempo = 0f;  // Contador para el tiempo que la luz está activada    
    [SerializeField] private float contadorTiempoEspera = 0f;  // Contador para el tiempo que la luz está activada    
    [SerializeField] private SpriteRenderer playerSprite;  // Contador para el tiempo que la luz está activada    

    private bool puedeSaltarDoble = false;  // Controla si se puede hacer el segundo salto    
    private bool enCooldown = false;  // Controla si está en cooldown
    private bool enCooldownEspera = false;  // Controla si está en cooldown
    private float longitudRaycast = 1f;  // Longitud del Raycast
    private Rigidbody2D rb;
    private bool isdead=false;
    private Collider2D playerCollider;

    void Awake()
    {
        // Asigna el tag "Player"
        gameObject.tag = "Player";
        rb = GetComponent<Rigidbody2D>();
        if (playerSprite == null) playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        brillo.SetActive(false);
        playerData.SetCheckpointPosition(transform.position);
    }
    void Update()
    {
        if(playerData.hasLight && playerData.controlEnable) LightControl();
        if(playerData.controlEnable) playerMovement();
        if (isdead) ReturnToCheckpoint();
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
        if (movimientoHorizontal < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
        rb.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);

        // Saltar y doble salto
        if (Input.GetButtonDown("Jump"))
        {
            if (estaEnSuelo)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                puedeSaltarDoble = true;
            }
            else if (puedeSaltarDoble && playerData.hasDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                puedeSaltarDoble = false;  // Desactiva el doble salto después de usarlo
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (playerData.isPaused)
            {

            }
            else
            {

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
        else
        {
            if (!enCooldown)
            {
                if (contadorTiempo > .2f)
                {
                    contadorTiempoEspera += Time.deltaTime;
                    if (contadorTiempoEspera >= cooldownDuracionEspera)// Si el tiempo máximo se ha alcanzado, desactiva la luz y empieza el cooldown
                    {
                        DesactivarLuzYEmpezarCooldownEspera();
                    }
                }
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
    void DesactivarLuzYEmpezarCooldownEspera()
    {
        contadorTiempoEspera = 0f;
        contadorTiempo = 0f;
    }
    IEnumerator Cooldown()
    {
        enCooldown = true;  // Marca que está en cooldown
        yield return new WaitForSeconds(cooldownDuracion);  // Espera el tiempo del cooldown
        enCooldown = false;  // Cooldown completado, puede activarse de nuevo
    }
    public void ChangeLightsize()
    {
        brillo.transform.localScale = Vector3.one * 5;
    }
    void ReturnToCheckpoint()
    {
        Vector2 destino = new Vector2(playerData.LastCheckpointPosition().x, playerData.LastCheckpointPosition().y);
        float fspeed = 5f;
        float distancia = Vector2.Distance(rb.position, destino);
        if (distancia > .3f)
        {
            Vector2 direccion = (destino - rb.position).normalized;
            rb.velocity = direccion * fspeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            playerData.controlEnable = true;
            isdead = false;
            playerCollider.enabled = true;
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
        }
    }
    public void Dead()
    {
        playerData.controlEnable = false;
        isdead = true;
        playerCollider.enabled = false;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
    }
}
