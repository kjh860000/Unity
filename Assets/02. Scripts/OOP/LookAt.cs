using System.Collections;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPos;

    public float fireDelay = 0.1f; // �߻� ����
    private bool canFire = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            StartCoroutine(Use());
        }

        Look();
    }

    IEnumerator Use()
    {
        canFire = false;

        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPos.right * 100f, ForceMode.Impulse);

        yield return new WaitForSeconds(fireDelay); // ������ �� �߻� ����
        canFire = true;
    }

    public void Look()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseWorldPos - transform.position).normalized;
        direction.z = 0;
        transform.right = direction;
    }
}
