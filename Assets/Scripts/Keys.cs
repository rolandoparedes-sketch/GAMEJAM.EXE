using UnityEngine;

public class Keys : MonoBehaviour
{
    public string keyColor; // Ejemplo: "rojo", "verde", "azul"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerKeys playerKeys = collision.GetComponent<PlayerKeys>();
            if (playerKeys != null)
            {
                playerKeys.AddKey(keyColor);
                Debug.Log("Recogiste la llave " + keyColor);
                Destroy(gameObject); // Desaparece la llave
            }
        }
    }
}