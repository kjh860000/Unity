using UnityEngine;

public class Pattern0 : MonoBehaviour
{
    [SerializeField]
    private NoteSpawner noteSpawner;
    private void Update()
    {
        PatternOff();
    }
    private void OnEnable()
    {
        noteSpawner.gameObject.SetActive(true);
    }
    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {

            gameObject.SetActive(false);
        }
    }
}
