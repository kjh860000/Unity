using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public IDropItem currentItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            currentItem.Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            IDropItem item = other.GetComponent<IDropItem>();

            //item.Grab(); // æ∆¿Ã≈€ »πµÊ

            currentItem = item; // «ˆ¿Á æ∆¿Ã≈€ ¿Â¬¯
        }
    }
}