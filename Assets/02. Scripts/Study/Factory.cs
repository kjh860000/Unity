using UnityEngine;

public class Factory<T> : MonoBehaviour // 컴파일 타임에서 T를 결정
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"Factory는 {typeof(T)} 타입");
    }
}
