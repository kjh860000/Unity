using UnityEngine;

public class OffbeatNote : MonoBehaviour
{
    private NoteSoundManager NoteSM;

    void Awake()
    {
        NoteSM = FindObjectOfType<NoteSoundManager>();
    }
    public void Start()
    {
        //NoteSM.BombSound();
    }

}
