using UnityEngine.UI;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button inventoryButton;

    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform slotGroup;

    public Slot[] slots;

    private void Start()
    {
        slots = slotGroup.GetComponentsInChildren<Slot>(true);  //true: off되어있는 것도 모두 가져옴
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    public void DropItem(Vector3 dropPos)
    {
        // 랜덤 아이템
        var randomIndex = Random.Range(0, items.Length);

        // 아이템 생성
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2, 2), ForceMode2D.Impulse);
        itemRb.AddForceY(4f, ForceMode2D.Impulse); // Impulse: 한순간 빠르게, Force: 부드럽게

        float ranPower = Random.Range(-5f, 5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (var slot in slots) // 모든 슬롯에 대해서
        { 
            if (slot.isEmpty)   // 슬롯이 비어있을 경우
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}

