using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;           
    public float lifeTime = 3f;         
    public float confuseDuration = 3f;  
    public int damage = 1;              

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        rb.linearVelocity = transform.up * speed;

        
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Main_Enemy enemy = other.GetComponent<Main_Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                enemy.Confuse(confuseDuration);
            }

            
            Destroy(gameObject);
        }
    }

}