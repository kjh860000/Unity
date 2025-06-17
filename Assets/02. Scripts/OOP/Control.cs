using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform grabPos;
    private IDropItem currentItem;

    private void Update()
    {
        Move();
        Interaction();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Interaction()
    {
        if (currentItem == null) 
            return;

        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
            currentItem = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDropItem>() != null)
        {
            currentItem = other.GetComponent<IDropItem>();

            currentItem.Grab(grabPos);
        }
    }
}
