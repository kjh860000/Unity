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

        Debug.Log("손전등을 주웠다.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf);

        Debug.Log("라이트를 켠다.");
    }

    public void Drop()
    {
/*        transform.SetParent(null);
        transform.position = Vector3.zero;

        Debug.Log("손전등을 버렸다.");*/

        transform.SetParent(null);

        // 바닥에 버릴 위치 설정 (캐릭터 위치 기준으로 약간 앞, 바닥 근처로)
        Vector3 dropPosition = new Vector3(transform.position.x, 0f, transform.position.z); // 바닥이 y = 0인 경우
        dropPosition += transform.forward * 0.5f; // 약간 앞에 떨어지게 함

        transform.position = dropPosition;

        Debug.Log("손전등을 버렸다.");
    }
}