using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeleport : MonoBehaviour
{
    public string doorColor;        // Color que requiere la puerta
    public string sceneToLoad;      // Nombre de la escena a cargar (debe estar agregada en Build Settings)
    public Vector2 spawnPosition;   // Coordenadas destino si no cambias de escena
    public bool changeScene = true; // Cambiar de escena o solo moverse dentro de la misma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerKeys playerKeys = collision.GetComponent<PlayerKeys>();

            if (playerKeys != null)
            {
                if (playerKeys.HasKey(doorColor))
                {
                    Debug.Log("Puerta " + doorColor + " abierta!");
                    if (changeScene)
                        SceneManager.LoadScene(sceneToLoad);
                    else
                        collision.transform.position = spawnPosition;
                }
                else
                {
                    Debug.Log("Necesitas la llave " + doorColor + "!");
                }
            }
        }
    }
}