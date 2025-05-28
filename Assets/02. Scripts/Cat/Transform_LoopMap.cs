using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 15;
    public float randomPosY;

    public float maxLength;
    public float minLength;

    public Vector3 returnPos;


/*    void Start()
    {
        returnPos = new Vector3(30f, height, 0f);    // 배경이미지 길이, 높이

    }*/
    void Update()
    {

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        //Debug.Log(Time.fixedDeltaTime);

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(minLength, maxLength);
            transform.position = new Vector3(returnPosX, randomPosY, 0f);
        }
    }
}
