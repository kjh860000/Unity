using UnityEngine;

public class Study_invoke : MonoBehaviour
{
    //public float timer = 5;
    void Start()
    {
        //Invoke : Ÿ�̸� �Լ� ���
        //Invoke("Method1", timer);

        //Invoke ���
        //CancelInvoke("Method1");

        //Invoke �ݺ� (�Լ���, ó�� �����ð�, ���ʸ��� ����)
        InvokeRepeating("Method1", 3f, 1f);
    }

    void Method1()
    {
        Debug.Log("invoke �޼��� ����");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Method1");
        }
    }
}
