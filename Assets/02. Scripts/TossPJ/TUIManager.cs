using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TUIManager : MonoBehaviour
{

    [SerializeField]
    private TGameManager tGameManager;
    [SerializeField]
    private JudgeManager judgeManager;

    [Header("Main UI")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textMainGrade;

    [Header("Game UI")]
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private TextMeshProUGUI textScore; // Legacy - Text로 변경

    [Header("Result UI")]
    [SerializeField]
    private GameObject resultPanel;

    //[Header("Bgm UI")]
    //[SerializeField]
    //private GameObject bgmPanel;


    [Header(" ")]
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textResultGrade;
    [SerializeField]
    private TextMeshProUGUI textResultHighScore;    
    [SerializeField]
    private TextMeshProUGUI textResultHighGrade;
    [SerializeField]
    private TextMeshProUGUI textKillCount;
    [SerializeField]
    private TextMeshProUGUI textCritCount;

    [SerializeField]
    private TextMeshProUGUI textfireCount;

    [SerializeField]
    private TextMeshProUGUI textExGrade;
    [SerializeField]
    private TextMeshProUGUI textMGrade;
    [SerializeField]
    private TextMeshProUGUI textGodGrade;



    private void Awake()
    {
/*        PlayerPrefs.DeleteKey("HIGHSCORE");
        PlayerPrefs.DeleteKey("HIGHGRADE");
        PlayerPrefs.DeleteKey("EX");
        PlayerPrefs.DeleteKey("MASTER");
        PlayerPrefs.DeleteKey("GOD");*/

        textMainGrade.text = PlayerPrefs.GetString("HIGHGRADE");

        // 해금 여부 불러오기
        if (PlayerPrefs.GetInt("EX", 0) == 1)
        {
            textExGrade.text = "EX";
            textExGrade.enableVertexGradient = true;
        }

        if (PlayerPrefs.GetInt("MASTER", 0) == 1)
        {
            textMGrade.text = "MASTER";
            textMGrade.enableVertexGradient = true;
        }

        if (PlayerPrefs.GetInt("GOD", 0) == 1)
        {
            textGodGrade.text = "GOD";
            textGodGrade.enableVertexGradient = true;
        }
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void GameOver()
    {
        int currentScore = (int)tGameManager.CurrentScore;

        textResultScore.text = currentScore.ToString();

        // 이번 게임 등급 계산
        string currentGrade = CalculateGrade(currentScore);
        textResultGrade.text = currentGrade;

        if (currentGrade == "EX" || currentGrade == "MASTER" || currentGrade == "GOD")
        {
            textExGrade.text = "EX";
            textExGrade.enableVertexGradient = true;
        }

        if (currentGrade == "MASTER" || currentGrade == "GOD")
        {
            textMGrade.text = "MASTER";
            textMGrade.enableVertexGradient = true;
        }

        if (currentGrade == "GOD")
        {
            textGodGrade.text = "GOD";
            textGodGrade.enableVertexGradient = true;
        }

        // 최고 점수 및 등급 계산
        CalculateHighScore(currentScore, currentGrade);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        textKillCount.text = judgeManager.killcount.ToString();
        textCritCount.text = judgeManager.critcount.ToString();
    }
    // 점수 기준 등급 반환
    private string CalculateGrade(int score)
    {
        if (score < 10000) return "N";       // 최저 등급
        else if (score < 20000) return "F";
        else if (score < 30000) return "E";
        else if (score < 40000) return "D";
        else if (score < 50000) return "C";
        else if (score < 60000) return "B";
        else if (score < 70000) return "A";
        else if (score < 80000) return "S";
        else if (score < 90000) return "S+";
        else if (score < 100000) return "SS";
        else if (score < 110000) return "SS+";
        else if (score < 120000) return "SSS";
        else if (score < 130000) return "SSS+";
        else if (score < 140000) return "EX";
        else if (score < 150000) return "MASTER";
        else return "GOD";
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GoToBgm()
    {
        mainPanel.SetActive(false);
        //bgmPanel.SetActive(true);
    }

    private void Update()
    {
        textScore.text = tGameManager.CurrentScore.ToString("F0");
        textfireCount.text = judgeManager.fireCritCount.ToString("F0");
        textKillCount.text = judgeManager.killcount.ToString();
        textCritCount.text = judgeManager.critcount.ToString();
    }

    private void CalculateHighScore(int score, string currentGrade)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        string highGrade = PlayerPrefs.GetString("HIGHGRADE", "F");

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            PlayerPrefs.SetString("HIGHGRADE", currentGrade);

            textResultHighScore.text = score.ToString();
            textResultHighGrade.text = currentGrade.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
            textResultHighGrade.text = highGrade.ToString();
        }

        if (score >= 140000) PlayerPrefs.SetInt("EX", 1);
        if (score >= 150000) PlayerPrefs.SetInt("MASTER", 1);
        if (score >= 150000) PlayerPrefs.SetInt("GOD", 1); // 16만 -> 15만점 이상으로 변경
    }

}
