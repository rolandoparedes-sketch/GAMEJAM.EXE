using UnityEngine;

public class Candy : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<GameManager>().contador++;
            print("Le sirvo comida al cliente");
            Destroy(gameObject);
        }
    }

}
