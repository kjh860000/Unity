using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100;

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
