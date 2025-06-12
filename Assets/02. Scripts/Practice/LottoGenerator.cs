using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoGenerator : MonoBehaviour
{
    //public int[] intArray = new int[10];  // 배열은 미리 만들어 놓는 방식 (자리바꿈)
    public List<int> intList = new List<int>(); // 추가, 삭제, 삽입 가능 방식

    public int shakeCount = 1000;

    private void Awake()
    {
        for (int i = 1; i< 46; i++) // 1 ~ 45
        {
            intList.Add(i);
        }
    }
    /*    IEnumerator Start()
        {
            for (int i = 0; i < shakeCount; i++)
            {
                int ranInt1 = Random.Range(0, intArray.Length);
                int ranInt2 = Random.Range(0, intArray.Length);

                var temp = intArray[ranInt1];
                intArray[ranInt1] = intArray[ranInt2];
                intArray[ranInt2] = temp;

                yield return new WaitForSeconds(0.1f);
            }
        }*/

    IEnumerator Start()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            int ranInt1 = Random.Range(0, intList.Count);
            int ranInt2 = Random.Range(0, intList.Count);

            var temp = intList[ranInt1];
            intList[ranInt1] = intList[ranInt2];
            intList[ranInt2] = temp;

            yield return new WaitForSeconds(0.001f);
        }

        List<int> resultGroup = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            resultGroup.Add(intList[i]);
        }

        resultGroup.Sort();

        string resultNumber = $"이번 주 로또 번호 : {resultGroup[0]} / {resultGroup[1]} / {resultGroup[2]} /" +
            $" {resultGroup[3]} / {resultGroup[4]} / {resultGroup[5]} / 보너스 : {intList[6]}";


        Debug.Log(resultNumber);
    }
}
