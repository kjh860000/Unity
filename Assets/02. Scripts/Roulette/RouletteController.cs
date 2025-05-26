using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0f;
    public bool isStop = false;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); //z축 기준으로 회전
        //transform.Rotate(0f, 0f, rotSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) //getkeydown이기 때문에 한번만 실행됨
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
