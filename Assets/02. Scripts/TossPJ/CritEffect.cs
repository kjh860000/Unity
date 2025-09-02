using UnityEngine;

public class CritEffect : MonoBehaviour
{
    private JudgeManager judgeM;
    private TMonster tM;

    [SerializeField] private GameObject[] objs; // 생성 오브젝트

    void Awake()
    {
        judgeM = FindObjectOfType<JudgeManager>();
        tM = GetComponent<TMonster>();
        if (tM == null)
        {
            UnityEngine.Debug.LogWarning("TMonster 컴포넌트를 찾지 못했습니다.");
        }
    }

    private void Start()
    {
        //NoteSM.Sound();
    }

    private void OnDestroy()
    {
        //Debug.Log($"CritEffect. dontEffect={tM.dontEffect}, isCrit={judgeM.isCrit}");

        if (tM.dontEffect)
            return;

        if (judgeM.isCrit)
        {
            //Debug.Log("CritEffect생성");
            Instantiate(objs[0], transform.position, Quaternion.identity);  //Slash effect
            Instantiate(objs[2], transform.position, Quaternion.identity);  //Crit effect
            Instantiate(objs[3], transform.position, Quaternion.identity);  //Black effect
            Instantiate(objs[4], transform.position, Quaternion.identity);  //Crit2 effect

            if (judgeM.isOver30)
            {
                Instantiate(objs[5], transform.position, Quaternion.identity);  //shock effect
            }
            judgeM.isCrit = false;
        }
        else
        {
            //Debug.Log("Normal Effect생성");
            Instantiate(objs[1], transform.position, Quaternion.identity);  //Mon Dummy
            Instantiate(objs[3], transform.position, Quaternion.identity);  //Black effect
        }
    }
}
