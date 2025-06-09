using UnityEngine;

public class Study_Random : MonoBehaviour
{
    private void OnEnable()
    {
        //int ranNumber1 = Random.Range(0, 100); // 0 ~ 99
        float ranNumber2 = Random.Range(0f, 100f); // 0 ~ 100

        //Debug.Log(ranNumber1);
        Debug.Log(ranNumber2);

    }
}
