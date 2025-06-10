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
                return; // 실행하지않고 빠져나옴
            
            timer += Time.deltaTime;

            playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            scoreUI.text = $"<color=red>X</color> {score}";
        }
    }
}

