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
        slots = slotGroup.GetComponentsInChildren<Slot>(true);  //true: off�Ǿ��ִ� �͵� ��� ������
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    public void DropItem(Vector3 dropPos)
    {
        // ���� ������
        var randomIndex = Random.Range(0, items.Length);

        // ������ ����
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2, 2), ForceMode2D.Impulse);
        itemRb.AddForceY(4f, ForceMode2D.Impulse); // Impulse: �Ѽ��� ������, Force: �ε巴��

        float ranPower = Random.Range(-5f, 5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (var slot in slots) // ��� ���Կ� ���ؼ�
        { 
            if (slot.isEmpty)   // ������ ������� ���
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}

