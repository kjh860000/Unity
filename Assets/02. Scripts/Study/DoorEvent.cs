using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Open");
    }
    void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("Close");
    }

}
