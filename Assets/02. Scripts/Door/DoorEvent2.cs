using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator animator;

    public string openKey;
    public string closeKey;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(openKey);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(closeKey);
    }
}
