using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item;   //���Կ� ���� ������
    public Image itemImage;  //������ �̹��� ��ġ
    public Button slotButton;   //������ Use() ��ư

    public bool isEmpty = true;
    private void Awake()
    {
        slotButton = GetComponent<Button>();
        itemImage = transform.GetChild(0).GetComponent<Image>();

        slotButton.onClick.AddListener(UseItem);
    }
    private void OnEnable()
    {
/*        if (isEmpty)
        {
            slotButton.interactable = false;
            itemIcon.gameObject.SetActive(false);
        }
        else
        {
            slotButton.interactable = true;
            itemIcon.gameObject.SetActive(true);
        }
*/
        // �� �ڵ带 �ٿ��� �ڵ�
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();

        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }
    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
