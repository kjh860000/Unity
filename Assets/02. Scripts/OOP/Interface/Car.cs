using UnityEngine;

public class Car : MonoBehaviour, IMove
{
    public float moveSpeed;

    public void Move()
    {
        UnityEngine.Debug.Log("Move");
    }
}
