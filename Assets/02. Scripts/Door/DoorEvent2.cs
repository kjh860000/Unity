using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator animator;

    public string openKey;
    public string closeKey;

    public GameObject doorLock;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive (true);
            //animator.SetTrigger(openKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(false);
            //animator.SetTrigger(closeKey);
        }
    }
}
