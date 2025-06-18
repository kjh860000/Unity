using UnityEngine;

public interface IMove  //인터페이스 I 붙이기
{
    void Move()
    {
        Debug.Log("Move");
        //invoke, coroutine 못씀
    }
}
