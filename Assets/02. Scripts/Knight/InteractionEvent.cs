using System.Collections;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC}
    public InteractionType type;

    public GameObject Popup;

    public FadeRoutine fade;

    public GameObject map;
    public GameObject house;

    public float fadeTime;
    public bool isHouse;
    public bool isInteract;

    public Vector3 inDoorPos;
    public Vector3 outDoorPos;

    private Transform playerTransform;
    public SoundCotroller soundCotroller;
    private void Update()
    {
        if (isInteract && Input.GetKeyDown(KeyCode.G))
        {
            if (Popup.activeSelf)
            {
                Popup.SetActive(false);
            }
            else
            {
                Interaction(playerTransform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteract = true;
            Debug.Log("G키를 눌러 상호작용");
            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteract = false;
            playerTransform = other.transform;
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                Popup.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                Popup.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        soundCotroller.EventSoundPlay("Door");

        yield return StartCoroutine(fade.Fade(fadeTime, Color.black, true));

        map.SetActive(isHouse);
        house.SetActive(!isHouse);

        var pos = isHouse ? outDoorPos : inDoorPos;

        player.transform.position = pos;

        isHouse = !isHouse;
        yield return StartCoroutine(fade.Fade(fadeTime, Color.black, false));
    }
}
