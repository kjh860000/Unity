using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {
        MouseClickEvent();

    }
    void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("Mouse Button Down");
        }
        if (Input.GetMouseButton(0))
        {
            UnityEngine.Debug.Log("Mouse Button");
        }
        if (Input.GetMouseButtonUp(0))
        {
            UnityEngine.Debug.Log("Mouse Button up");
        }
    }
}
