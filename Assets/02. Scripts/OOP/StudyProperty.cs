using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    private int number1 = 10;
    public int Number1  // ĸ��ȭ, ù �빮�ڴ� ���
    {
        get { return number1; }
        set { number1 = value; }
    }

    public int Number2 { get; set; } = 20;
    public int Number3 { get; private set; } = 30;

    private void Start()
    {
        Number1 = 10;
        Number2 = 20;
        Number3 = 30;
    }
}
