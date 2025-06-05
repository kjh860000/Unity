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
                Debug.Log("�Է� �ؽ�Ʈ ����");
            }
            else
            {
                playObj.SetActive(true);
                IntroUI.SetActive(false);

                Debug.Log($"���� {nameTextUI} �Է�");
                nameTextUI.text = inputField.text;
            }
        }
    }
}

