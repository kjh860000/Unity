using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawnManager;

    private SpriteRenderer sRenderer;
    private Animator animator;

    protected float hp = 3f;
    protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init();    //initialize 초기화

    private void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Init();
    }
    private void Update()
    {
        Move();
    }

/*    void OnMouseDown()
    {
        Debug.Log("MouseClick");

        StartCoroutine(Hit(1));
    }*/

    void Move()
    {
        if (!isMove)
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
        
    }

    public IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break; // return

        isHit = true;
        isMove = false;

        //Debug.Log("hit");

        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");
            spawnManager.DropCoin(transform.position);

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);  // 리소스를 많이 먹음 => setActive로 대체


            yield break;
        }

        animator.SetTrigger("Hit");
        Debug.Log("Hit");

        yield return new WaitForSeconds(0.65f);
        isHit = false;
        isMove = true;
    }
}
