using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    //private Coroutine runningCoroutine;
    private bool isStop = false;
    void Start()
    {
        StartCoroutine(BombRoutine());
        //runningCoroutine = StartCoroutine(RoutineA());

        //StopCoroutine(runningCoroutine);
        //StartCoroutine(RoutineA());
        //Invoke("MethodA", 1f);
        //Invoke("StopMethod", 3f);
    }
    IEnumerator RoutineA()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("코루틴 실행");
    }

    void MethodA()
    {
        Debug.Log("123");
    }

    private void StopMethod()
    {
        StopCoroutine(RoutineA());
    }

    IEnumerator BombRoutine()
    {
        int t = 10;
        while (t > 0)
        {
            Debug.Log($"{t}초 남았습니다");
            yield return new WaitForSeconds(1f);
            t--;

            if (isStop)
            {
                Debug.Log("폭탄 해제");
                yield break; // break : 반복문 탈출 / yield break : 코루틴 탈출
            }
        }
        Debug.Log("펑");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isStop = true;
        }
    }
}
