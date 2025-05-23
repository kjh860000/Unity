using UnityEngine;

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // update전 한번만 실행
    void Start()
    {
        Debug.Log(this.name); // this : 해당 스크립트가 적용된 오브젝트
        //Debug.Log("start 함수 실행");
        //Debug.LogWarning("start 함수 실행");
        //Debug.LogError("start 함수 실행");
    }

    // Update is called once per frame
    // 매 프레임마다 실행
    void Update()
    {
    }
}
