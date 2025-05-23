using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime;
    void Start()
    {
        Destroy(this.gameObject, destroyTime); // 3초 후 자기자신 파괴

    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴 되었습니다");
    }
}
