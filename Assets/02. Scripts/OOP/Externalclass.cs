using UnityEngine;

public class Externalclass : MonoBehaviour
{
    public StudyProperty studyProperty;

    private void Start()
    {
        //int num1 = studyProperty.number1; //private
        int num1 = studyProperty.Number1;
        studyProperty.Number1 = 100;

        int num2 = studyProperty.Number2;
        studyProperty.Number2 = 200;
    }
}
