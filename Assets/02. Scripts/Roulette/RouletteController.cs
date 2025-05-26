using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0f;
    public bool isStop = false;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); //z�� �������� ȸ��
        //transform.Rotate(0f, 0f, rotSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) //getkeydown�̱� ������ �ѹ��� �����
        {
            isStop = true;
        }

        if(isStop)
        {
            rotSpeed *= 0.98f;
            if(rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
