using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;

        public void Start () 
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // 사운드파일 설정
            audioSource.playOnAwake = true; // 자동재생
            audioSource.loop = true; // 반복기능
            audioSource.volume = 0.1f; // 소리음량

            audioSource.Play();

            //audioSource.Stop();
            //audioSource.Pause();
        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
