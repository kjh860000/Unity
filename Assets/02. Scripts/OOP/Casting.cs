using System;
using UnityEngine;
using System.Collections.Generic;

public class Casting : MonoBehaviour
{
    /*    List<Orc> orcs = new List<Orc>();
        List<Goblin> goblins = new List<Goblin>();

        List<Monster> monsters = new List<Monster>();*/

    // generic : ��Ÿ�ӽ� Ÿ�԰����� �ƴ� ȣ��� �����ǹǷ� �������� x
    public List<int> intList = new List<int>();
    public List<GameObject> objList = new List<GameObject>();
    public List<Vector3> vecList = new List<Vector3>();

    private void Start()
    {
        /*        Orc o = new Orc();
                Goblin g = new Goblin();

                ///�ٿ� ĳ����
                Monster m5 = new Monster();
                Orc o2 = (Orc)m5;


                ///�� ĳ����
                // ����� ����ȯ
                Monster m1 = (Monster) o;
                Monster m2 = (Monster) g;

                // �Ͻ��� ����ȯ
                Monster m3 = o;
                Monster m4 = g;

                monsters.Add(o);
                monsters.Add(g);*/

        //------------------------------------------------------

        /*        Monster m = new Monster();

                //Orc o1 = m; // �Ͻ��� ����ȯ x
                //Orc o = (Orc)m; // ����� ����ȯ -> ����

                Orc o = m as Orc; // as: �ϴ� ���� (������ ����ȯ ���н� null)

                if (o != null)
                {
                    Debug.Log(o);
                }
                else
                {
                    Debug.Log("����ȯ x");
                }*/
        //------------------------------------------------------
    }
}
