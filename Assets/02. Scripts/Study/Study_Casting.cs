using System;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    /*    int number1 = 1;
        float number2 = 1.23f;
    */
    private void Start()
    {
        /*        number1 = (int)number2;
                Debug.Log(number1);*/

        //--------------------------------------//

        /*        string str1 = "123";
                string str2 = "456";

                int num1 = int.Parse(str1);
                int num2 = int.Parse(str2);

                Debug.Log($""+num1 + num2);     // 123456
                Debug.Log($""+(num1 + num2));   // 579
                Debug.Log($"{num1} + {num2}");  // 123+456*/

        //--------------------------------------//

        /*        int num1 = 123;
                string str = num1.ToString();   //"123"
        */

        //--------------------------------------//

        /*        int num0 = 0;
                int num1 = -1;
                int num2 = 2;
                int num100 = 100;

                float fNum0 = 0f;
                float fNum1 = 1.57f;
                float fNum2 = 3.14f;

                string str1 = "hello";
                string str2 = "true";
                string str3 = "false";

                //int는 0만 false 나머지 true (음수 포함)
                Debug.Log("num0 " + Convert.ToBoolean(num0));
                Debug.Log("num1 " + Convert.ToBoolean(num1));
                Debug.Log("num2 " + Convert.ToBoolean(num2));
                Debug.Log("num100 " + Convert.ToBoolean(num100));

                Debug.Log("fNum0 " + Convert.ToBoolean(fNum0));
                Debug.Log("fNum1 " + Convert.ToBoolean(fNum1));
                Debug.Log("fNum2 " + Convert.ToBoolean(fNum2));

                Debug.Log("str2 " + Convert.ToBoolean(str2)); // true
                Debug.Log("str3 " + Convert.ToBoolean(str3)); // false
                Debug.Log("str1 " + Convert.ToBoolean(str1)); // error*/

        //--------------------------------------//

        bool isbool1 = true;
        bool isbool2 = false;

        int num1 = Convert.ToInt32(isbool1);
        int num2 = Convert.ToInt32(isbool2);

        Debug.Log(num1);
        Debug.Log(num2);
    }
}
