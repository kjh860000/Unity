using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime;
    void Start()
    {
        Destroy(this.gameObject, destroyTime); // 3�� �� �ڱ��ڽ� �ı�

    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}�� �ı� �Ǿ����ϴ�");
    }
}
