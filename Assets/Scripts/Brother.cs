using UnityEngine;

public class Brother : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hermano donde estabas? te estuve buscando, volvamos a casa :(");
            gameObject.SetActive(false); 
        }
    }
}
