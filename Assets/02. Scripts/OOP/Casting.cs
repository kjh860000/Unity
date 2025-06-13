using System;
using UnityEngine;
using System.Collections.Generic;

public class Casting : MonoBehaviour
{
    /*    List<Orc> orcs = new List<Orc>();
        List<Goblin> goblins = new List<Goblin>();

        List<Monster> monsters = new List<Monster>();*/

    // generic : 런타임시 타입결정이 아닌 호출시 결정되므로 성능저하 x
    public List<int> intList = new List<int>();
    public List<GameObject> objList = new List<GameObject>();
    public List<Vector3> vecList = new List<Vector3>();

    private void Start()
    {
        /*        Orc o = new Orc();
                Goblin g = new Goblin();

                ///다운 캐스팅
                Monster m5 = new Monster();
                Orc o2 = (Orc)m5;


                ///업 캐스팅
                // 명시적 형변환
                Monster m1 = (Monster) o;
                Monster m2 = (Monster) g;

                // 암시적 형변환
                Monster m3 = o;
                Monster m4 = g;

                monsters.Add(o);
                monsters.Add(g);*/

        //------------------------------------------------------

        /*        Monster m = new Monster();

                //Orc o1 = m; // 암시적 형변환 x
                //Orc o = (Orc)m; // 명시적 형변환 -> 에러

                Orc o = m as Orc; // as: 일단 실행 (성공시 형변환 실패시 null)

                if (o != null)
                {
                    Debug.Log(o);
                }
                else
                {
                    Debug.Log("형변환 x");
                }*/
        //------------------------------------------------------
    }
}
