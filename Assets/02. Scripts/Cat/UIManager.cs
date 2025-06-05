using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject IntroUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("입력 텍스트 없음");
            }
            else
            {
                playObj.SetActive(true);
                IntroUI.SetActive(false);

                Debug.Log($"현재 {nameTextUI} 입력");
                nameTextUI.text = inputField.text;
            }
        }
    }
}

