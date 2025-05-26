using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;

    void Update()
    {
        // 월드방향 이동
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; 
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World); 

        // 로컬방향 이동
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 

        // 월드방향 회전
        //transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0f);

        // 로컬방향 회전
        //transform.localRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0f);

        // 로컬 방향으로 회전
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // space.self 생략

        // 월드 방향으로 회전
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World); 

        // 특정위치를 기준으로 회전
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f,1f,0f), rotateSpeed * Time.deltaTime);


    }
}
