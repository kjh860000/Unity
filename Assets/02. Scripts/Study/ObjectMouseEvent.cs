using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseEnter()
    {
        UnityEngine.Debug.Log("OnMouseEnter");
    }
    private void OnMouseOver()
    {
        UnityEngine.Debug.Log("OnMouseOver");
    }
    private void OnMouseDown()
    {
        UnityEngine.Debug.Log("OnMouseDown");
    }
    private void OnMouseDrag()
    {
        UnityEngine.Debug.Log("OnMouseDrag");
    }
    private void OnMouseUp()
    {
        UnityEngine.Debug.Log("OnMouseUp");
    }
    private void OnMouseUpAsButton()
    {
        UnityEngine.Debug.Log("OnMouseUpAsButton");
    }
    private void OnMouseExit()
    {
        UnityEngine.Debug.Log("OnMouseExit");
    }
}
