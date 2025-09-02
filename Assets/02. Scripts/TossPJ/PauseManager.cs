using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject buttonStart;
    public GameObject buttonPause;
    public TextMeshProUGUI countdownText;

    private bool isPaused = false;
    private bool isResuming = false; // 코루틴 중복 방지

    public void TogglePause()
    {
        if (isPaused)
        {
            if (!isResuming)
                StartCoroutine(ResumeWithCountdown());
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        buttonStart.SetActive(true);
        buttonPause.SetActive(false);

        AudioListener.pause = true;
    }

    IEnumerator ResumeWithCountdown()
    {
        isResuming = true; // 실행 중임 표시

        if (pausePanel != null)
            pausePanel.SetActive(true);

        float countdown = 3f;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString("F1");
            yield return null;
            countdown -= Time.unscaledDeltaTime;
        }

        countdownText.text = "Pause";

        Time.timeScale = 1f;
        isPaused = false;
        isResuming = false; // 끝났음 표시

        if (pausePanel != null)
            pausePanel.SetActive(false);

        buttonStart.SetActive(false);
        buttonPause.SetActive(true);

        AudioListener.pause = false;
    }
}
