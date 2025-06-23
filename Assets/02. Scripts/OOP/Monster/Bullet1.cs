using System.Collections;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("Bullet hit");
            Monster monster = other.GetComponent<Monster>();

            StartCoroutine(monster.Hit(1));
        }
    }

    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
