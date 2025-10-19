using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    private HashSet<string> keys = new HashSet<string>();

    public void AddKey(string color)
    {
        keys.Add(color);
    }

    public bool HasKey(string color)
    {
        return keys.Contains(color);
    }
}
