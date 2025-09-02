using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class PatternManager : MonoBehaviour
{
    [SerializeField]
    private TGameManager tGameManager;
    [SerializeField]
    private NoteSpawner noteSpawner;
    [SerializeField]
    private NoteSoundManager noteSoundManager;
    [SerializeField]
    private GameObject[] BGMs;
    [SerializeField]
    private GameObject[] patterns;          // 보유하고 있는 모든 패턴
    private GameObject currentPattern;

    [SerializeField] private TextMeshProUGUI infoText;

    private int[] patternIndexs;        // 겹치지 않는 patterns.Length 개수의 숫자
    private int current = 0;        // patternIndexs 배열의 순번

    private int randomRunCount = 0;         // 현재 랜덤 실행 횟수
    private int numberOfRandomPatterns = 2; // 현재 랜덤 선택 개수


    private void Awake()
    {
        // 보유하고 있는 패턴(patterns) 개수와 동일하게 메모리 할당
        patternIndexs = new int[patterns.Length];

        // 처음에는 패턴을 순차적으로 실행하도록 설정
        for (int i = 0; i < patternIndexs.Length; ++i)
        {
            patternIndexs[i] = i;
        }
    }

    private void Update()
    {
        if (tGameManager.IsGamePlay == false) return;

        // 현재 재생중인 패턴이 종료되어 오브젝트가 비활성화되면
        if (currentPattern.activeSelf == false)
        {
            // 다음 패턴 실행
            ChangePattern();
        }
    }

    public void GameStart()
    {
        gameObject.SetActive(true);
        ChangePattern();
    }

    public void GameOver()
    {
        // 현재 재생중인 패턴만 비활성화
        currentPattern.SetActive(false);
        gameObject.SetActive(false);

        foreach (GameObject bgm in BGMs)
        {
            if (bgm != null)
                bgm.SetActive(false);
        }
    }

    private List<int> unusedPatternIndices; // 클래스 상단에 추가

    private HashSet<int> usedSecondPatterns = new HashSet<int>();

    public void ChangePattern()
    {
        UnityEngine.Debug.Log("NextPattern");
        TextFadeInOut fadeScript = infoText.GetComponent<TextFadeInOut>();

        if (current < patternIndexs.Length)
        {
            if (current == 0) // 첫 번째 패턴은 [0] 고정
            {
                currentPattern = patterns[patternIndexs[current]];
                currentPattern.SetActive(true);
                current++;

                // 랜덤용 리스트는 [2]번부터 시작 (0,1 제외)
                unusedPatternIndices = patternIndexs.Skip(2).ToList();
            }
            else if (current == patternIndexs.Length - 1) // 마지막 패턴은 [1] 고정
            {
                currentPattern = patterns[1];
                currentPattern.SetActive(true);
                current++;
            }
            else // 중간 패턴은 랜덤 실행
            {
                if (unusedPatternIndices.Count > 0)
                {
                    int randomIndex = Random.Range(0, unusedPatternIndices.Count);
                    int chosenPatternIndex = unusedPatternIndices[randomIndex];

                    currentPattern = patterns[chosenPatternIndex];
                    currentPattern.SetActive(true);

                    // 선택된 패턴 제거
                    unusedPatternIndices.RemoveAt(randomIndex);
                    current++;
                }
            }
        }
        else
        {
            randomRunCount++;

            // 랜덤 패턴 개수 설정 및 UI
            if (randomRunCount <= 5) numberOfRandomPatterns = 2;
            else if (randomRunCount <= 9) numberOfRandomPatterns = 3;
            else if (randomRunCount <= 12) numberOfRandomPatterns = 4;
            else if (randomRunCount <= 14) numberOfRandomPatterns = 5;
            else numberOfRandomPatterns = 6;

            infoText.text = $"Pattern x{numberOfRandomPatterns}";
            fadeScript.PlayFade();

            List<int> selectedIndices = new List<int> { 1 }; // 1번 무조건 포함

            if (numberOfRandomPatterns == 2)
            {
                // 0,1 제외 + 아직 선택되지 않은 것만 후보
                List<int> candidates = Enumerable.Range(2, patterns.Length - 2)
                                                 .Where(i => !usedSecondPatterns.Contains(i))
                                                 .ToList();

                if (candidates.Count == 0)
                {
                    Debug.LogWarning("모든 2번째 패턴이 이미 사용됨!");
                }
                else
                {
                    int rand = Random.Range(0, candidates.Count);
                    int chosen = candidates[rand];
                    selectedIndices.Add(chosen);
                    usedSecondPatterns.Add(chosen); // 전체 중복 방지
                }
            }
            else
            {
                // 3개 이상일 경우 기존 로직
                int[] randomIndices = Utils.RandomNumbers(patterns.Length - 2, numberOfRandomPatterns - 1);
                for (int i = 0; i < randomIndices.Length; i++)
                    randomIndices[i] += 2;

                selectedIndices.AddRange(randomIndices);
            }

            // 모든 패턴 비활성화
            foreach (GameObject pattern in patterns)
                pattern.SetActive(false);

            // 선택된 패턴 활성화
            foreach (int index in selectedIndices)
                patterns[index].SetActive(true);

            // 대표 패턴은 1번
            currentPattern = patterns[1];
        }

        if (noteSoundManager.isRandom)
            noteSoundManager.PlaySameRandomBGM();
    }

}
