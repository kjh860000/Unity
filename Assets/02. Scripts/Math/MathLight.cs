using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        theta += Time.deltaTime;
        light.intensity = Mathf.Sin(theta) * power;
    }
}
