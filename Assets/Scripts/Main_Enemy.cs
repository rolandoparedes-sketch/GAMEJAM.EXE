using UnityEngine;

public class Main_Enemy : MonoBehaviour
{
    public Transform player;
    public Transform flashlight;
    public float chaseSpeed = 4f;
    public float stopDistance = 0.5f;
    public float visionRange = 10f;

    private bool isIlluminated = false;
    private Rigidbody2D rb;

    public int health = 3;

    
    private bool isConfused = false;
    private float confuseTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
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

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void DetectFlashlightHit()
    {
        Vector2 lightDir = flashlight.up;
        int layerMask = ~LayerMask.GetMask("Player"); 
        RaycastHit2D hit = Physics2D.Raycast(flashlight.position, lightDir, visionRange, layerMask);

        isIlluminated = hit.collider != null && hit.collider.transform == transform;
    }

    
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }

    
    public void Confuse(float duration)
    {
        isConfused = true;
        confuseTimer = duration;
    }
}






