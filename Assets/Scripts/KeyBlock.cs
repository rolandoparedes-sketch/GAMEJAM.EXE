using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    [Header("Color de llave necesaria (ej: rojo, verde, azul, celeste)")]
    public string requiredKeyColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerKeys playerKeys = collision.collider.GetComponent<PlayerKeys>();

            if (playerKeys != null)
            {
                if (playerKeys.HasKey(requiredKeyColor))
                {
                    Debug.Log("Tienes la llave " + requiredKeyColor + ". Puedes entrar por la puerta " + requiredKeyColor + ".");
                    Destroy(gameObject); 
                }
                else
                {
                    Debug.Log("No tienes la llave " + requiredKeyColor + ". No puedes pasar aún.");
                    
                }
            }
        }
    }
}