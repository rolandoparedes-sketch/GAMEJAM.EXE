using UnityEngine;

public class Enemie : MonoBehaviour
{
    public float speed = 3f;
    public float vision = 10f; // Rango de visión aumentado
    public float rangeAttack = 2f; // Rango de ataque
    public GameObject Player;
    public float distancia;
    public float contador = 0f;

    void Update()
    {
        contador += Time.deltaTime;
        PerseguirJugador();
        AtacarJugador();
    }
    public void PerseguirJugador()
    {
        distancia = Vector3.Distance(transform.position, Player.transform.position); // Calcula la distancia al jugador
        Vector3 direccion = (Player.transform.position - transform.position).normalized;// Dirección hacia el jugador
        transform.position += direccion * speed * Time.deltaTime;// Mueve al enemigo hacia el jugador
        
    }
    public void AtacarJugador()
    {
        if(distancia <= rangeAttack && contador >= 3f)
        {
            Player.GetComponent<Player>().health--;
            contador = 0f;
        }
    }

}

