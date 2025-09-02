using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject[] objs; // 생성 오브젝트

    private void Start()
    {
        //NoteSM.Sound();
    }

    private void OnDestroy()
    {
        foreach (var obj in objs)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }
}
