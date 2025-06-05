using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    private int count = 0;
    void Start()
    {
        /*        while (count < 10)
                {
                    count++;
                    Debug.Log($"현재 {count}");
                }*/

        /*        do
                {
                    count++;
                    Debug.Log($"현재 {count}");
                }
                while (count < 7);*/

        /*        while (count < 10)
                {
                    count++;
                    Debug.Log($"현재 {count}");

                    if (count == 5)
                    {
                        break;
                    }
                }*/

        /*        while (count < 10)
                {
                    count++;

                    if (count == 5)
                    {
                        continue; // 다시 반복문으로 (Debug.Log 건너뜀)
                    }
                    Debug.Log($"현재 {count}");
                }*/

        while (count <= 10) // 369 게임
        {
            count++;

            if (count % 3 == 0) //3의 배수
            {
                Debug.Log("짝!");
                continue;
            }
            Debug.Log(count);
        }
    }
    void Update()
    {
        
    }
}
