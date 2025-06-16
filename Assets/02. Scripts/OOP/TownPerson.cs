using UnityEngine;

public class TownPerson : MonoBehaviour, IMove, ITalk
{
    public float hp;
    public float speed;

    public void Move()
    {
        Debug.Log("Move");
        transform.position += transform.right * speed * Time.deltaTime;
    }
    public void Talk()
    {
        Debug.Log("Talk");
    }

    void Update()
    {
        Move();
    }
}