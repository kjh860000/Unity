using UnityEngine;

public class Debugg : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log(gameObject.name + "가 활성화되었습니다. (true)");
    }

    private void OnDisable()
    {
        Debug.Log(gameObject.name + "가 비활성화되었습니다. (false)");
    }
}
