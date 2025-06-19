using UnityEngine;

public class MathCircle : MonoBehaviour
{
    private float theta;
    [SerializeField] private float speed, radius;
    void Update()
    {
        theta += Time.deltaTime * speed;

        Vector2 pos = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;
        transform.position = pos;
    }
}
