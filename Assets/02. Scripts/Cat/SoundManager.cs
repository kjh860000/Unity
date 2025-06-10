using UnityEngine;
using UnityEngine.Video;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip introBgmClip;
        public AudioClip playBgmClip;

        public AudioClip jumpClip;
        public AudioClip colliderClip;

        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
            {
                audioSource.clip = introBgmClip;
            }
            else if (bgmName == "Play")
            {
                audioSource.clip = playBgmClip;
            }

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
        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }


    }
}
