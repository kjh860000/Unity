using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2, 2), ForceMode2D.Impulse);
        itemRb.AddForceY(4f, ForceMode2D.Impulse); // Impulse: 한순간 빠르게, Force: 부드럽게

        float ranPower = Random.Range(-5f, 5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {

    }
}

