using UnityEngine;

public class MathDot : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    private void Start()
    {
        float result1 = Vector3.Dot(vecA, vecB); // Dot

        Vector3 result2 = Vector3.Cross(vecA, vecB); // Cross

        Vector3 result3 = Vector3.Reflect(vecA, vecB); // Reflect
    }
}
