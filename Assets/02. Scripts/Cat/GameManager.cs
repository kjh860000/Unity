using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager SoundManager;

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score;
        public static bool isPlay;

        private void Start()
        {
            SoundManager.SetBGMSound("Intro");
        }
        private void Update()
        {
            if (!isPlay)
                return; // ���������ʰ� ��������
            
            timer += Time.deltaTime;

            playTimeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer);
            scoreUI.text = $"<color=red>X</color> {score}";
        }
    }
}

