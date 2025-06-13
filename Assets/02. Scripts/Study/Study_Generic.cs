using UnityEngine;

public class Study_Generic : MonoBehaviour
{
/*    void Start()
    {
        Factory<Monster> factory = new Factory<Monster>();
    }*/

    // 오버로딩 : 동일한 함수명에 매개변수만 다르게 사용하는 방법
    public void CreateAccount(string name)
    {
        int dummyAge = 20;
        CreateAccount(name, dummyAge);
    }
    public void CreateAccount(string name, int age)
    {
        string dummyPhoneNumber = "01012345678";
        CreateAccount(name, age, dummyPhoneNumber);
    }
    public void CreateAccount(string name, int age, string phoneNumber)
    {
        string dummyeMail = "hello@unity.com";
        CreateAccount(name, age, phoneNumber, dummyeMail);
    }
    public void CreateAccount(string name, int age, string phoneNumber, string eMail)
    {

    }
}

