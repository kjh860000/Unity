using UnityEngine;

public class Study_Overloading : MonoBehaviour
{
    private void Start()
    {
        Attack();
        Attack(true);
        Attack(10f);
        Attack(10f, new GameObject("����"));
    }

    public void Attack()
    {
        Debug.Log("����");
    }
    public void Attack(bool isMagic)
    {
        if (isMagic)
        {
            Debug.Log("���� ����");
        }
    }
    public void Attack(float damage)
    {
        Debug.Log($"{damage} ����");
    }
    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target}���� {damage} ����");
    }

}
