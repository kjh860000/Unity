using UnityEngine;

public class Factory<T> : MonoBehaviour // ������ Ÿ�ӿ��� T�� ����
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"Factory�� {typeof(T)} Ÿ��");
    }
}
