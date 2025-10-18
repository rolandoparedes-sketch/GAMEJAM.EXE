using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Main_Player player = other.GetComponent<Main_Player>();
            if (player != null)
            {
                player.EquipWeapon(weaponPrefab); 
                Destroy(gameObject); 
            }
        }
    }
}
