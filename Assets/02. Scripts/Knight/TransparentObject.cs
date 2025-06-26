using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float Alpha = 0.4f;
    private float orignlAlpha;
    private int originLayer;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        orignlAlpha = sprite.color.a;
        originLayer = sprite.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.sortingOrder = originLayer + 1;
            Color color = sprite.color;
            color.a = Alpha;
            sprite.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.sortingOrder = originLayer;
            Color color = sprite.color;
            color.a = orignlAlpha;
            sprite.color = color;
        }
    }
}

