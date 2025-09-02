using UnityEngine;

public class MathVector : MonoBehaviour
{
    public Vector3 vecA = new Vector3(3,0,0);
    public Vector3 vecB = new Vector3(0,4,0);

    private void Start()
    {
        float size = Vector3.Magnitude(vecA + vecB);
        UnityEngine.Debug.Log($"Magnitude : {size}");

        float distance = Vector3.Distance(vecA, vecB);
        UnityEngine.Debug.Log($"Distance : {distance}");

        float size2 = Vector3.SqrMagnitude(vecA + vecB);
        UnityEngine.Debug.Log($"SqrMagnitude : {size2}");
    }
}
