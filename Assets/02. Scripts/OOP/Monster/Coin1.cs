using UnityEngine;

public class Coin1 : MonoBehaviour, IItem
{
    public Inventory inventory;
    public enum CoinType { Gold, Purple, Blue }
    public CoinType coinType;

    public float price;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }

    private void OnMouseDown()
    {
        Get();
    }
    public GameObject Obj { get; set; }
    public void Get()
    {
        Debug.Log($"{name} È¹µæ");
        inventory.AddItem(this);
        gameObject.SetActive(false);
    }
}
