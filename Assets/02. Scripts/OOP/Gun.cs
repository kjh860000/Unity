using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("���� �ֿ���.");
    }

    public void Use()
    {
        Debug.Log("���� �߻��Ѵ�.");
    }

    public void Drop()
    {
        Debug.Log("���� ���ȴ�.");
    }
}