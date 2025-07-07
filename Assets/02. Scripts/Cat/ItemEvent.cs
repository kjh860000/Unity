using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType {Pipe1, Pipe2, Apple1, Apple2, Both1, Both2, GApple}
    public ColliderType collidertype;

    public GameObject pipe;
    public GameObject apple;
    public GameObject gapple;
    public GameObject particle;


    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    private float randomPosY;

    private Vector3 initPos;

    void Awake()
    {
        initPos = transform.localPosition;
    }

    private void OnEnable()
    {
        SetRandomSetting(initPos.x);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
            SetRandomSetting(returnPosX);
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-10f, -6f);
        transform.position = new Vector3(posX, randomPosY, 0);

        pipe.SetActive(false);
        apple.SetActive(false);
        gapple.SetActive(false);
        particle.SetActive(false);

        collidertype = (ColliderType)Random.Range(0, 7);

        switch (collidertype)
        {
            case ColliderType.Pipe1:
                pipe.SetActive(true); 
                break;
            case ColliderType.Pipe2:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple1:
                apple.SetActive(true);
                break;
            case ColliderType.Apple2:
                apple.SetActive(true);
                break;
            case ColliderType.Both1:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
            case ColliderType.Both2:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
            case ColliderType.GApple:
                gapple.SetActive(true);
                break;
        }
    }

}