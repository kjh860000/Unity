using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;

    public void Grab()
    {
        Debug.Log("�������� �ֿ���.");
    }

    public void Use()
    {
        isLight = !isLight;
        lightObj.SetActive(isLight);

        Debug.Log("����Ʈ�� �Ҵ�.");
    }

    public void Drop()
    {
        Debug.Log("�������� ���ȴ�.");
    }
}