using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager SoundManager;

        public GameObject playObj;
        public GameObject IntroUI;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            playObj.SetActive(false);
            IntroUI.SetActive(true);
            playUI.SetActive(false);
        }
        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }
        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("�Է� �ؽ�Ʈ ����");
            }
            else
            {
                nameTextUI.text = inputField.text;
                SoundManager.SetBGMSound("Play");

                GameManager.isPlay = true;

                playObj.SetActive(true);
                playUI.SetActive(true);
                IntroUI.SetActive(false);
            }
        }
    }
}

