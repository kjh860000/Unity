using UnityEngine;

public class PlanetRoataion : MonoBehaviour
{
    public Transform targetPlanet;

    public float rotSpeed = 30; //자전속도

    public float revolutionSpeed = 100; //공전속도

    public bool isRevolution = false; 


    // Update is called once per frame
    void Update()
    {
        // 자전 기능
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isRevolution == true)
        {
            // 공전 기능
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
