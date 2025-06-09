using UnityEngine;

public class Study_invoke : MonoBehaviour
{
    //public float timer = 5;
    void Start()
    {
        //Invoke : 타이머 함수 기능
        //Invoke("Method1", timer);

        //Invoke 취소
        //CancelInvoke("Method1");

        //Invoke 반복 (함수명, 처음 지연시간, 몇초마다 실행)
        InvokeRepeating("Method1", 3f, 1f);
    }

    void Method1()
    {
        Debug.Log("invoke 메서드 실행");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Method1");
        }
    }
}
