using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeleport : MonoBehaviour
{
    public string doorColor;        
    public string sceneToLoad;      
    public Vector2 spawnPosition;   
    public bool changeScene = true; 

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