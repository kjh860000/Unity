using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height;

    public Vector3 returnPos;


    void Start()
    {
        returnPos = new Vector3(30f, height, 0f);    // 배경이미지 길이, 높이

    }
    void Update()
    {

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        Debug.Log(Time.fixedDeltaTime);

        if (transform.position.x <= -30f)
        {
            transform.position = returnPos;
        }
    }
}
