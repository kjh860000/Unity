using UnityEngine;

public class TownPerson : MonoBehaviour, IMove, ITalk
{
    public float hp;
    public float speed;

    public void Move()
    {
        UnityEngine.Debug.Log("Move");
        transform.position += transform.right * speed * Time.deltaTime;
    }
    public void Talk()
    {
        UnityEngine.Debug.Log("Talk");
    }

    void Update()
    {
        Move();
    }
}