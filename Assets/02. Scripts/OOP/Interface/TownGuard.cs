using UnityEngine;

public class TownGuard : MonoBehaviour, IMove, IAttack
{
    public void Move()
    {
        UnityEngine.Debug.Log("Move");
    }
    public void Attack()
    {
        UnityEngine.Debug.Log("Attack");
    }
}