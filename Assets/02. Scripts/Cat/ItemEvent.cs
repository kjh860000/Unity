using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType {Pipe, Apple, Both}
    public ColliderType collidertype;

    public GameObject pipe;
    public GameObject apple;
    public GameObject particle;


    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    private float randomPosY;

    void Start()
    {
        SetRandomSetting(transform.position.x);
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
        particle.SetActive(false);

        collidertype = (ColliderType)Random.Range(0, 3); // int´Â 0~2, float´Â 0~3

        switch (collidertype)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true); 
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
    }

}