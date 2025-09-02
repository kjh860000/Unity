using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(AudioSource))]
public class BGMMaster : MonoBehaviour
{
    public NoteSoundManager noteSoundManager;

    [HideInInspector] public AudioSource[] childBGMs;  // 자식 오디오소스 배열
    private AudioSource parentAudio;                    // 상위 오브젝트 AudioSource
    private int currentIndex = 0;

    public TextMeshProUGUI songTitleText;
    public TextMeshProUGUI ingameSongTitleText;
    public Slider volumeSlider;

    void Awake()
    {
        parentAudio = GetComponent<AudioSource>();

        // 자식 오디오소스만 가져오기 (부모 자신 제외)
        childBGMs = GetComponentsInChildren<AudioSource>();
        childBGMs = System.Array.FindAll(childBGMs, a => a != parentAudio);

        if (childBGMs.Length > 0)
        {
            currentIndex = 0;
            ApplyCurrentBGM();
            parentAudio.Stop();
        }
    }

    // 다음 곡
    public void NextBGM()
    {
        if (childBGMs.Length == 0) return;

        currentIndex++;
        if (currentIndex >= childBGMs.Length)
            currentIndex = 0;
        ApplyCurrentBGM();

        noteSoundManager.toggle.isOn = false;
    }

    // 이전 곡
    public void PrevBGM()
    {
        if (childBGMs.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = childBGMs.Length - 1;

        ApplyCurrentBGM();

        noteSoundManager.toggle.isOn = false;
    }

    // 현재 선택된 곡을 부모 오디오소스에 적용하고 재생
    private void ApplyCurrentBGM()
    {
        AudioSource currentBGM = childBGMs[currentIndex];

        parentAudio.clip = currentBGM.clip;
        parentAudio.pitch = currentBGM.pitch;
        parentAudio.loop = currentBGM.loop;

        parentAudio.volume = volumeSlider.value;

        parentAudio.Play();

        if (songTitleText != null)
            songTitleText.text = currentBGM.gameObject.name;        
        if (ingameSongTitleText != null)
            ingameSongTitleText.text = currentBGM.gameObject.name;

        Debug.Log("현재 곡: " + currentBGM.gameObject.name);
    }

    // 외부에서 제어 가능
    public void PlayBGM()
    {
        if (parentAudio.clip != null)
            parentAudio.Play();
    }

    public void StopBGM()
    {
        parentAudio.Stop();
    }

    public void PlayBGMByIndex(int index)
    {
        if (childBGMs.Length == 0) return;
        if (index < 0 || index >= childBGMs.Length) return;

        currentIndex = index;
        ApplyCurrentBGM();
    }

}
