using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; 
    public float confuseDuration = 3f; 

    void Start()
    {
        Destroy(gameObject, lifeTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Main_Enemy enemy = other.GetComponent<Main_Enemy>();
            if (enemy != null)
            {
                enemy.Confuse(3f); 
                enemy.TakeDamage(1); 
            }

            Destroy(gameObject);
        }
    }
}