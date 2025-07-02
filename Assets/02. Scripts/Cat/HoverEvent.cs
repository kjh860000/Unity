using UnityEngine;
using UnityEngine.UI;

public class HoverEvent : MonoBehaviour
{
    public GameObject obj;

    public void OnHoverEnter()
    {
        obj.SetActive(true);
    }

    public void OnHoverExit()
    {
        obj.SetActive(false);
    }
}
