using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonHandler : MonoBehaviour, IPointerDownHandler
{
    public JudgeManager judgeManager;
    public TPlayer tPlayer;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("버튼 눌림!");

       judgeManager.OnLeftButton();
       tPlayer.OnLeftButton();
    }
}
