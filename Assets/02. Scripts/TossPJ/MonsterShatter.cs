using System.Collections;
using UnityEngine;

public class MonsterShatter : MonoBehaviour
{
    private JudgeManager judgeM;
    private TMonster tM;

    [SerializeField] private GameObject[] Shatters;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    void Awake()
    {
        judgeM = FindObjectOfType<JudgeManager>();
        tM = FindObjectOfType<TMonster>();
    }

    private void OnDestroy()
    {
        if (tM.dontEffect)
            return;

        if (!judgeM.isCrit)
            return;

        DropShatter(transform.position);
        
    }

    public void DropShatter(Vector3 dropPos)
    {
        foreach (var shatter in Shatters)
        {
            GameObject shatters = Instantiate(shatter, dropPos, Quaternion.identity);
            Rigidbody2D itemRb = shatters.GetComponent<Rigidbody2D>();

            itemRb.AddForce(new Vector2(Random.Range(-minX, maxX), Random.Range(minY, maxY)), ForceMode2D.Impulse);
        }
    }
}
