using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    private int count = 0;
    void Start()
    {
        /*        while (count < 10)
                {
                    count++;
                    Debug.Log($"���� {count}");
                }*/

        /*        do
                {
                    count++;
                    Debug.Log($"���� {count}");
                }
                while (count < 7);*/

        /*        while (count < 10)
                {
                    count++;
                    Debug.Log($"���� {count}");

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
                        continue; // �ٽ� �ݺ������� (Debug.Log �ǳʶ�)
                    }
                    Debug.Log($"���� {count}");
                }*/

        while (count <= 10) // 369 ����
        {
            count++;

            if (count % 3 == 0) //3�� ���
            {
                Debug.Log("¦!");
                continue;
            }
            Debug.Log(count);
        }
    }
    void Update()
    {
        
    }
}
