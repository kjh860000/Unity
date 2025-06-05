using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton");
    }
    private void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }
}
