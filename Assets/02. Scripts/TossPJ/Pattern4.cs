using UnityEngine;

public class Pattern4 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;
    [SerializeField] private GameObject offBeatPrefab;
    [SerializeField] private GameObject notePrefab;

    [SerializeField] private GameObject[] Objects;
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private GameObject[] monEyes;

    GameObject remove = null;

    private void Update()
    {
        PatternOff();
    }
    private void OnEnable()
    {
        foreach (var obj in Objects)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        foreach (var obj in monEyes)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        foreach (var obj in clouds)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        noteSpawner.gameObject.SetActive(true);

        foreach (var note in noteSpawner.Notes)
        {
            if (note.name == "[Note] Mon1_Ed")  // 이름 비교
            {
                remove = note;
                break;
            }
        }
        if (remove != null)
        {
            noteSpawner.Notes.Remove(remove);
        }
        ////////////
        noteSpawner.Notes.Add(offBeatPrefab);
    }
    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
            foreach (var obj in Objects)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }

            foreach (var obj in monEyes)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }

            foreach (var obj in clouds)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }

            gameObject.SetActive(false);

            noteSpawner.Notes.Remove(offBeatPrefab);
            noteSpawner.Notes.Add(notePrefab);
        }
    }

}
