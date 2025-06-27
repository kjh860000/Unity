using UnityEngine;
using UnityEngine.UI;

public class SoundCotroller : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Toggle bgmMute;

    [SerializeField] private Slider eventVolume;
    [SerializeField] private Toggle eventMute;

    private void Awake()
    {
        bgmVolume.value = bgmAudio.volume;
        eventVolume.value = eventAudio.volume;

        bgmMute.isOn= bgmAudio.mute;
        eventMute.isOn= eventAudio.mute;
    }
    private void Start()
    {
        BgmSoundPlay("Town BGM");

        bgmVolume.onValueChanged.AddListener(OnBgmVolumeChanged);
        eventVolume.onValueChanged.AddListener(OnEventVolumeChanged);

        bgmMute.onValueChanged.AddListener(OnBgmMute);
        eventMute.onValueChanged.AddListener(OnEventMute);
    }

    public void BgmSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                bgmAudio.clip = clip;
                //bgmAudio.volume = 0.25f
                bgmAudio.Play();

                return;
            }
        }
    }

    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                eventAudio.PlayOneShot(clip);

                return;
            }
        }
        Debug.Log($"{clipName} do not found");
    }

    private void OnBgmVolumeChanged(float volume)
    {
        bgmAudio.volume = volume;
    }
    private void OnEventVolumeChanged(float volume)
    {
        eventAudio.volume = volume;
    }
    void OnBgmMute(bool isMute)
    {
        bgmAudio.mute = isMute;
    }
    void OnEventMute(bool isMute)
    {
        eventAudio.mute = isMute;
    }
}
