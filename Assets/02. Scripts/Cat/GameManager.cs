using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        playTimeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer);
    }
}
