using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            fadeUI.SetActive(true);
        }
    }


/*    void OnTriggerEnter(Collider other) // ��ȣ�ۿ��ϴ� �� �� �ϳ��� isTrigger = true�� ��� ȣ��
    {
        Debug.Log("Trigger Enter");
    }*/
}
