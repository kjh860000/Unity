using UnityEngine;

public class TownGuard : MonoBehaviour, IMove, IAttack
{
    public void Move()
    {
        Debug.Log("Move");
    }
    public void Attack()
    {
        Debug.Log("Attack");
    }
}