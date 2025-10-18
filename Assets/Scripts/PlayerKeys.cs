using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public int totalKeys = 0;
    public int requiredKeys = 3;

    public void AddKey()
    {
        totalKeys++;
        Debug.Log("Llaves recolectadas: " + totalKeys);

        if (totalKeys >= requiredKeys)
        {
            Debug.Log("¡Todas las llaves recolectadas!");
            
        }
    }
}