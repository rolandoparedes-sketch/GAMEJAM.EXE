using UnityEngine;

public class Keys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            collision.GetComponent<PlayerKeys>().AddKey();

            
            Destroy(gameObject);
        }
    }
}