using UnityEngine;

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // update�� �ѹ��� ����
    void Start()
    {
        Debug.Log(this.name); // this : �ش� ��ũ��Ʈ�� ����� ������Ʈ
        //Debug.Log("start �Լ� ����");
        //Debug.LogWarning("start �Լ� ����");
        //Debug.LogError("start �Լ� ����");
    }

    // Update is called once per frame
    // �� �����Ӹ��� ����
    void Update()
    {
    }
}
