using UnityEngine;

public class Study_For : MonoBehaviour
{
    //public int[] arrayInt = new int[5];

    void Start()
    {
/*        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }*/

/*        for (int i = 0; i < arrayInt.Length; i++)
        {
            Debug.Log(arrayInt[i]);
        }*/

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Debug.Log($"{i}/{j}");
            }
        }
    }

}
