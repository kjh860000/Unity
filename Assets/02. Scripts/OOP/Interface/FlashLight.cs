using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("�������� �ֿ���.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf);

        Debug.Log("����Ʈ�� �Ҵ�.");
    }

    public void Drop()
    {
/*        transform.SetParent(null);
        transform.position = Vector3.zero;

        Debug.Log("�������� ���ȴ�.");*/

        transform.SetParent(null);

        // �ٴڿ� ���� ��ġ ���� (ĳ���� ��ġ �������� �ణ ��, �ٴ� ��ó��)
        Vector3 dropPosition = new Vector3(transform.position.x, 0f, transform.position.z); // �ٴ��� y = 0�� ���
        dropPosition += transform.forward * 0.5f; // �ణ �տ� �������� ��

        transform.position = dropPosition;

        Debug.Log("�������� ���ȴ�.");
    }
}