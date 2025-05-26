using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;

    void Update()
    {
        // ������� �̵�
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; 
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World); 

        // ���ù��� �̵�
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 

        // ������� ȸ��
        //transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0f);

        // ���ù��� ȸ��
        //transform.localRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0f);

        // ���� �������� ȸ��
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // space.self ����

        // ���� �������� ȸ��
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World); 

        // Ư����ġ�� �������� ȸ��
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f,1f,0f), rotateSpeed * Time.deltaTime);


    }
}
