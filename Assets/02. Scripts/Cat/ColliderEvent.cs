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


/*    void OnTriggerEnter(Collider other) // 상호작용하는 둘 중 하나라도 isTrigger = true일 경우 호출
    {
        Debug.Log("Trigger Enter");
    }*/
}
