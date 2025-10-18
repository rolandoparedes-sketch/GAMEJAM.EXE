using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public void Fire(Vector2 firePosition, Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePosition, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        
        rb.linearVelocity = direction.normalized * bulletSpeed;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}