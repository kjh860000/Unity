using UnityEngine;

public class BombNote : MonoBehaviour
{
    public GameObject bombEffect; // Æø¹ß ÀÌÆåÆ® ÇÁ¸®ÆÕ
    private NoteSoundManager NoteSM;

    void Awake()
    {
        NoteSM = FindObjectOfType<NoteSoundManager>();
    }

    private void Start()
    {
        NoteSM.BombSound();
    }

    private void OnDestroy()
    {
        if (bombEffect != null)
        {
            // ÇöÀç À§Ä¡¿¡ Æø¹ß ÀÌÆåÆ® »ý¼º
            Instantiate(bombEffect, transform.position, Quaternion.identity);
        }
    }
}
