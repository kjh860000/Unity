using UnityEngine;

public class Study_Overloading : MonoBehaviour
{
    private void Start()
    {
        Attack();
        Attack(true);
        Attack(10f);
        Attack(10f, new GameObject("몬스터"));
    }

    public void Attack()
    {
        Debug.Log("공격");
    }
    public void Attack(bool isMagic)
    {
        if (isMagic)
        {
            Debug.Log("마법 공격");
        }
    }
    public void Attack(float damage)
    {
        Debug.Log($"{damage} 공격");
    }
    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target}에게 {damage} 공격");
    }

}
