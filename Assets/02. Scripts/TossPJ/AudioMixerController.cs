using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    public AudioSource bgm;
    public AudioMixer mixer;

    public float speed = 2f; // 2배속

    void Update()
    {
        bgm.pitch = speed;

        // 속도 → 세미톤 변화량 계산
        float semitones = 12f * Mathf.Log(speed, 2f);

        // AudioMixer PitchShifter로 역보정
        mixer.SetFloat("PitchShifter", -semitones);
    }
}
