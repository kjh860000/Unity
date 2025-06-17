using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private SpriteRenderer sRenderer;

    protected float hp = 3f;
    protected float moveSpeed = 3f;

    private int dir = 1;

    public abstract void Init();    //initialize 초기화

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        Init();
    }
    private void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        Hit(1);
        Debug.Log("hit");
    }

    void Move()
    {
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

    void Hit(float damage)
    {
        hp-= damage;

        if (hp <= 0)
        {
            Debug.Log("몬스터 사망");
            Destroy(gameObject);
        }
    }
}
