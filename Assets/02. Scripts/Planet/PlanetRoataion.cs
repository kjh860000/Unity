using UnityEngine;

public class PlanetRoataion : MonoBehaviour
{
    public Transform targetPlanet;

    public float rotSpeed = 30; //�����ӵ�

    public float revolutionSpeed = 100; //�����ӵ�

    public bool isRevolution = false; 


    // Update is called once per frame
    void Update()
    {
        // ���� ���
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isRevolution == true)
        {
            // ���� ���
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
