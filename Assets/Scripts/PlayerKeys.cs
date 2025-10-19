using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public List<string> keys = new List<string>();

    public void AddKey(string keyColor)
    {
        if (!keys.Contains(keyColor))
        {
            keys.Add(keyColor);
            Debug.Log("Llave " + keyColor + " obtenida");
        }
    }

    public bool HasKey(string keyColor)
    {
        return keys.Contains(keyColor);
    }
}
