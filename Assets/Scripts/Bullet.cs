using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; // tiempo hasta destruir la bala
    public float confuseDuration = 3f; // tiempo que el enemigo se queda quieto

    void Start()
    {
        Destroy(gameObject, lifeTime); // destrucción automática
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Main_Enemy enemy = other.GetComponent<Main_Enemy>();
            if (enemy != null)
            {
                enemy.Confuse(3f); // confunde al enemigo 3 segundos
                enemy.TakeDamage(1); // opcional, si quieres que también reciba daño
            }

            Destroy(gameObject);
        }
    }
}