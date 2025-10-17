using UnityEngine;

public class Main_Enemy : MonoBehaviour
{
    public Transform player;   
    public Transform flashlight;   
    public float chaseSpeed = 6f;   
    public float stopDistance = 0.5f; 
    public float visionRange = 10f; 

    private bool isIlluminated = false;

    void Update()
    {
        if (player == null || flashlight == null) return;

        DetectFlashlightHit();

        if (!isIlluminated)
        {
            
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)(direction * chaseSpeed * Time.deltaTime);

                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }
    }

    void DetectFlashlightHit()
    {
        
        Vector2 lightDir = flashlight.up;

        
        RaycastHit2D hit = Physics2D.Raycast(flashlight.position, lightDir, visionRange);

        if (hit.collider != null)
        {
            
            if (hit.collider.transform == transform)
            {
                isIlluminated = true;
                return;
            }
        }

        
        isIlluminated = false;
    }

    void OnDrawGizmosSelected()
    {
        
        if (flashlight != null)
        {
            Gizmos.color = isIlluminated ? Color.green : Color.red;
            Gizmos.DrawLine(flashlight.position, flashlight.position + flashlight.up * visionRange);
        }
    }
}







