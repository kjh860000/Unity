using UnityEngine;

public class EarPhone : MonoBehaviour
{
    public string name;
    public float price;
    public int releaseYer;

    public void PlayMusic()
    {
        UnityEngine.Debug.Log("Music play");
    }
}
