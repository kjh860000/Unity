using System.Collections;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

            //StartCoroutine(DestroyWait());
        }
    }

    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
