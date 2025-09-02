using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonHandler : MonoBehaviour, IPointerDownHandler
{
    public JudgeManager judgeManager;
    public TPlayer tPlayer;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("버튼 눌림!");

        judgeManager.OnRightButton();
        tPlayer.OnRightButton();
    }
}
