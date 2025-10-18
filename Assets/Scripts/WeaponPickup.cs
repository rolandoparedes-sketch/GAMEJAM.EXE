using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // Prefab del arma que el jugador va a equipar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Main_Player player = other.GetComponent<Main_Player>();
            if (player != null)
            {
                player.EquipWeapon(weaponPrefab); // Le damos el arma al jugador
                Destroy(gameObject); // Desaparece del mapa
            }
        }
    }
}
