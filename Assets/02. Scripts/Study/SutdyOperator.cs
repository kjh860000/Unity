using UnityEngine;

public class SutdyOperator : MonoBehaviour
{
    public int currentLevel = 10;
    public int maxLevel = 99;


    void Start()
    {
        //bool isMax = currentLevel > maxLevel;
        //Debug.Log($"���� ������ ������ {isMax} �Դϴ�.");

        //���׿�����
        string msg = currentLevel >= maxLevel ? "���� �����Դϴ�" : "���� ������ �ƴմϴ�";

        int levelPoint = currentLevel >= maxLevel ? 0 : 1;

        currentLevel += levelPoint;
        Debug.Log(msg);
    }

}
