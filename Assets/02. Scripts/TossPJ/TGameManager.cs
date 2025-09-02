using UnityEngine;

public class TGameManager : MonoBehaviour
{
    [SerializeField]
    private TUIManager tUIManager;

    [SerializeField]
    private PatternManager pManager;

    [SerializeField]
    private GameObject gameScene1;

    [SerializeField]
    private GameObject noteSoundManager;

    private readonly float scoreScale = 20;     // 점수 증가 계수 (읽기전용)

    public float scoreMultiplier = 1f; // 기본 1배
    // 플레이어 점수 (죽지않고 버틴 시간)
    public float CurrentScore { private set; get; } = 0;

    public bool IsGamePlay { private set; get; } = false;

    public void GameStart()
    {
        tUIManager.GameStart();

        pManager.GameStart();

        IsGamePlay = true;

        gameScene1.SetActive(true);
        //noteSoundManager.SetActive(true);
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
    }

    public void GameOver()
    {
        tUIManager.GameOver();

        pManager.GameOver();

        IsGamePlay = false;

        gameScene1.SetActive(false);
        //noteSoundManager.SetActive(false);
    }

    private void Update()
    {
        if (IsGamePlay == false) return;

        CurrentScore += Time.deltaTime * scoreScale * scoreMultiplier;
    }

    public void PlusScore(float Plus)
    {
        CurrentScore += Plus * scoreMultiplier;
    }

    public void MinusScore(float Minus)
    {
        CurrentScore -= Minus;
    }
}

