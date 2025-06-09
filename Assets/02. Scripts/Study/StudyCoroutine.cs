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
        Debug.Log("�ڷ�ƾ ����");
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
            Debug.Log($"{t}�� ���ҽ��ϴ�");
            yield return new WaitForSeconds(1f);
            t--;

            if (isStop)
            {
                Debug.Log("��ź ����");
                yield break; // break : �ݺ��� Ż�� / yield break : �ڷ�ƾ Ż��
            }
        }
        Debug.Log("��");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isStop = true;
        }
    }
}
