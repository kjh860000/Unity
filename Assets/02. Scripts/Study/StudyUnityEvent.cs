using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    void Awake()
    {
        UnityEngine.Debug.Log("Awake");
    }

    void Start()
    {
        UnityEngine.Debug.Log("Start");
    }

    void OnEnable()
    {
        UnityEngine.Debug.Log("OnEnable");
    }
    void OnDisable()
    {
        UnityEngine.Debug.Log("OnDisable");
    }
    void Update()
    {

    }
}