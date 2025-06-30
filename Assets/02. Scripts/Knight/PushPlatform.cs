using System;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D targetRb;

    public float force;
    public float wait;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", wait);
        }
    }

    void PushCharacter()
    {
        targetRb.AddForceY(force, ForceMode2D.Impulse);
        animator.SetTrigger("Push");
    }
}
