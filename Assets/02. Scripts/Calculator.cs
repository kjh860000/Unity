using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1, number2;
    void Start()
    {
        int addResult = AddMethod();
        int minusResult = MinusMethod();

        Debug.Log($"´õÇÑ °ª : {addResult} / »« °ª : {minusResult}");
    }

    int AddMethod()
    {
        int result = number1 + number2;

        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;

        return result;
    }
}
