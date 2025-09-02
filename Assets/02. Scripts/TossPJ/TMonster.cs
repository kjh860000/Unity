using UnityEngine;
using System.Collections;

public class TMonster : MonoBehaviour
{
    private Animator anim;
    private Transform childTransform;

    public float fallSpeed = 6f;
    public float moveSpeed = 0.2f;
    public float moveDistance = 1.5f;
    public float waitTimer = 0.3f;

    public bool isfade = false;
    public bool dontEffect = false;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        childTransform = transform.Find("Judge");  // 미리 찾기 (한 번만)
    }
    void Update()
    {
        MonsterMove();
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTimer);
        isfade = true;
    }

    public void MonsterMove()
    {
        if (transform.position.y >= -3.2f)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            // 좌우 이동만
            if (transform.position.x < 0 && transform.position.x < -moveDistance)
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            else if (transform.position.x > 0 && transform.position.x > moveDistance)
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.y <= -3.05f)
            {
                dontEffect = true;

                //Debug.Log($"TMonster.dontEffect = {dontEffect}");

                childTransform.gameObject.SetActive(false);
                StartCoroutine(WaitTime());

                anim.SetTrigger("Bite");
            }
        }
        else if (transform.position.y <= -3.05f)
        {
            if (transform.position.x < 0)
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            else if (transform.position.x > 0)
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
    }
}
