using UnityEngine;
using System.Collections;

public class Main_Enemy : MonoBehaviour
{
    public Transform player;
    public Transform flashlight;
    public float chaseSpeed = 4f;
    public float stopDistance = 0.5f;
    public float visionRange = 10f;
    public int health = 3;
    public float respawnDelay = 7f; 

    private bool isIlluminated = false;
    private Rigidbody2D rb;

    private bool isConfused = false;
    private float confuseTimer = 0f;
    private Vector2 initialPosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        initialPosition = transform.position; 

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    void Update()
    {
        if (player == null || flashlight == null) return;

        
        if (isConfused)
        {
            confuseTimer -= Time.deltaTime;
            if (confuseTimer <= 0f)
                isConfused = false;

            rb.linearVelocity = Vector2.zero;
            return;
        }

        DetectFlashlightHit();

        if (!isIlluminated)
        {
            ChasePlayer();
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            rb.linearVelocity = direction * chaseSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Convertir a grados
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void DetectFlashlightHit()
    {
        Vector2 lightDir = flashlight.up; // Asumiendo que la luz apunta hacia arriba del transform
        int layerMask = ~LayerMask.GetMask("Player");// Ignorar la capa del jugador
        RaycastHit2D hit = Physics2D.Raycast(flashlight.position, lightDir, visionRange, layerMask);// Ignorar la capa del jugador

        isIlluminated = hit.collider != null && hit.collider.transform == transform;// Verificar si el rayo golpea este enemigo
    }

    // Recibir daño
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            StartCoroutine(RespawnAfterDelay());
            gameObject.SetActive(false); 
        }
    }

    
    public void Confuse(float duration) 
    {
        isConfused = true; // Activar estado confundido
        confuseTimer = duration; // Establecer temporizador de confusión
    }

    
    IEnumerator RespawnAfterDelay() // Nueva función de respawn
    {
        yield return new WaitForSeconds(respawnDelay);


        Vector2 randomOffset = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // Desplazamiento aleatorio
        transform.position = initialPosition + randomOffset; // Reposicionar con desplazamiento aleatorio

        health = 3; 
        isConfused = false; 
        gameObject.SetActive(true); 
    }
}






