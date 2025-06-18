using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    [SerializeField] private GameObject[] items;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8, 8);
            var randomY = Random.Range(-2, 5);

            var createPos = new Vector3(randomX, randomY, 0);

            Instantiate(monsters[randomIndex],createPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2, 2), ForceMode2D.Impulse);
        itemRb.AddForceY(4f, ForceMode2D.Impulse); // Impulse: 한순간 빠르게, Force: 부드럽게

        float ranPower = Random.Range(-5f, 5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}
