using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("ÃÑÀ» ÁÖ¿ü´Ù.");
    }

    public void Use()
    {
        Debug.Log("ÃÑÀ» ¹ß»çÇÑ´Ù.");
    }

    public void Drop()
    {
        Debug.Log("ÃÑÀ» ¹ö·È´Ù.");
    }
}