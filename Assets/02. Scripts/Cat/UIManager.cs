using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager SoundManager;
        //public CatChoose catChoose;

        public GameObject playObj;
        public GameObject IntroUI;
        public GameObject playUI;
        public GameObject ChooseUI;
        public GameObject videoPanel;
        public GameObject catsGroup;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button chooseButton;
        public Button startButton;
        public Button reStartButton;

        private void Awake()
        {
            playObj.SetActive(false);
            IntroUI.SetActive(true);
            playUI.SetActive(false);
            ChooseUI.SetActive(false);
        }
        private void Start()
        {
            chooseButton.onClick.AddListener(OnChooseButton);
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnRestartButton);
        }
        public void OnChooseButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("입력 텍스트 없음");
            }
            else
            {
                nameTextUI.text = inputField.text;

                ChooseUI.SetActive(true);
                IntroUI.SetActive(false);
            }
        }
        public void OnStartButton()
        {
            SoundManager.SetBGMSound("Play");

            GameManager.isPlay = true;

            playObj.SetActive(true);
            playUI.SetActive(true);
            ChooseUI.SetActive(false);
        }
        void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            playObj.SetActive(true); 
            playUI.SetActive(true);
            videoPanel.SetActive(false);
            catsGroup.SetActive(true);
        }
    }
}

