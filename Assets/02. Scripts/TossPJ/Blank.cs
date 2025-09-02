using System.Collections;
using UnityEngine;

public class Blank : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
