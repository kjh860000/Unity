using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }


/*    void OnTriggerEnter(Collider other) // ��ȣ�ۿ��ϴ� �� �� �ϳ��� isTrigger = true�� ��� ȣ��
    {
        Debug.Log("Trigger Enter");
    }*/
}
