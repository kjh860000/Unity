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
            audioSource.clip = bgmClip; // �������� ����
            audioSource.playOnAwake = true; // �ڵ����
            audioSource.loop = true; // �ݺ����
            audioSource.volume = 0.1f; // �Ҹ�����

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
