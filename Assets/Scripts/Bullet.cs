using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;           // Velocidad de la bala
    public float lifeTime = 3f;         // Cu�nto dura antes de destruirse
    public float confuseDuration = 3f;  // Tiempo que el enemigo queda confundido
    public int damage = 1;              // Da�o que causa

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Aplica movimiento hacia adelante desde donde apunta el arma
        rb.linearVelocity = transform.up * speed;

        // Destruye la bala despu�s del tiempo de vida
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

            // Destruye la bala al impactar
            Destroy(gameObject);
        }
    }

}