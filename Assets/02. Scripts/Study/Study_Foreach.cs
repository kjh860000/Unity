using UnityEngine;

public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5] {"가영", "나영", "다영", "라영", "마영" };
    public string findName;
    void Start()
    {
        FindPerson(findName);
    }

    private void FindPerson(string name)
    {
        bool isFind = false;

        foreach (var person in persons)
        {
            if (person == name)
            {
                isFind = true;
                Debug.Log($"{name} 존재합니다.");
            }
        }
        if (!isFind)
        {
            Debug.Log($"{name}을 찾지 못함.");
        }
    }
}
