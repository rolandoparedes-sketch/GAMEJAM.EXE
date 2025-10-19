using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public float pickupRange = 1.2f; 
    public LayerMask keyLayer;       
    public PlayerKeys playerKeys;    

    void Update()
    {
        DetectAndCollectKeys();
    }

    void DetectAndCollectKeys()
    {
        Collider2D[] nearbyKeys = Physics2D.OverlapCircleAll(transform.position, pickupRange, keyLayer); // Detect keys within range

        foreach (Collider2D key in nearbyKeys)
        {
            if (key.CompareTag("Key"))
            {
                playerKeys.AddKey(); 
                Destroy(key.gameObject);
                Debug.Log("Llave recogida");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}