using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    public Inventory inventory;
    public enum PotionType { Gold, Hp, Mp }
    public PotionType potionType;

    void Start()
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
