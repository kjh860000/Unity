using UnityEngine;
using UnityEngine.UI;

public class NoteSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] bgms;
    [SerializeField] private AudioSource[] sounds;

    [SerializeField] public Slider bgmsVolume;
    [SerializeField] public Slider soundsVolume;

    // 원래 볼륨 저장용
    private float[] originalBgmVolumes;
    private float[] originalSoundVolumes;

    public AudioSource leftNoteAudio;
    public AudioSource rightNoteAudio;
    public AudioSource leftNoteAudio2;
    public AudioSource rightNoteAudio2;

    public AudioSource hitLeftNoteAudio;
    public AudioSource hitRightNoteAudio;
    public AudioSource hitLeftNoteAudio2;
    public AudioSource hitRightNoteAudio2;

    public AudioSource hitNoteAudio;

    public AudioSource bombSound;
    public AudioSource explodeSound;
    public AudioSource critSound;

    public AudioSource enemyAttackAudio;
    public AudioSource swingAudio;
    public AudioSource thunderAudio;
    public AudioSource introBomb;
    public AudioSource overDrive;

    public Toggle toggle;        // UI Toggle
    public bool isRandom = true; // 커스텀 변수

    [SerializeField]
    private BGMMaster[] bgmMasters; // BGM, BEAT


    void Awake()
    {
        if (toggle != null)
            toggle.onValueChanged.AddListener(OnToggleChanged);


        // 원래 볼륨 저장
        originalBgmVolumes = new float[bgms.Length];
        for (int i = 0; i < bgms.Length; i++)
        {
            if (bgms[i] != null)
                originalBgmVolumes[i] = bgms[i].volume;
        }

        originalSoundVolumes = new float[sounds.Length];
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i] != null)
                originalSoundVolumes[i] = sounds[i].volume;
        }

        // 초기 슬라이더 값 적용
        OnBgmVolumeChanged(bgmsVolume.value);
        OnEventVolumeChanged(soundsVolume.value);

    }
    public void SetBgmPitch(float speedMultiplier)
    {
        for (int i = 0; i < bgms.Length; i++)
        {
            if (bgms[i] != null)
            {
                // 원래 피치(1)에 speedMultiplier를 곱함
                bgms[i].pitch = 1f * speedMultiplier;
            }
        }
    }

    private void Start()
    {
        bgmsVolume.onValueChanged.AddListener(OnBgmVolumeChanged);
        soundsVolume.onValueChanged.AddListener(OnEventVolumeChanged);
    }

    private void OnBgmVolumeChanged(float value)
    {
        for (int i = 0; i < bgms.Length; i++)
        {
            if (bgms[i] != null)
                bgms[i].volume = value; // 슬라이더 값 그대로 적용
        }
    }

    private void OnEventVolumeChanged(float value)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i] != null)
                sounds[i].volume = value; // 슬라이더 값 그대로 적용
        }
    }
    public void PlaySameRandomBGM()
    {
        if (bgmMasters == null || bgmMasters.Length == 0) return;

        int randomIndex = Random.Range(0, bgmMasters[0].childBGMs.Length);

        foreach (BGMMaster bgm in bgmMasters)
        {
            if (bgm != null)
            {
                bgm.PlayBGMByIndex(randomIndex);

                for (int i = 0; i < bgms.Length; i++)
                {
                    if (bgms[i] != null)
                        bgms[i].volume = originalBgmVolumes[i] * bgmsVolume.value;
                }
            }
        }
    }

    public void OnToggleChanged(bool value)
    {
        isRandom = value; // 토글 상태와 변수 동기화
        Debug.Log("isRandom: " + isRandom);
    }
    public void PlayLeftSound()
    {
        if (leftNoteAudio != null)
        {
            leftNoteAudio.Play();
            leftNoteAudio2.Play();
        }
    }

    public void PlayRightSound()
    {
        if (rightNoteAudio != null)
        {
            rightNoteAudio.Play();
            rightNoteAudio2.Play();
        }
    }

    public void HitLeftSound()
    {
        if (hitLeftNoteAudio != null)
        {
            hitLeftNoteAudio.Play();
            hitLeftNoteAudio2.Play();
        }
    }

    public void HitRightSound()
    {
        if (hitRightNoteAudio != null)
        {
            hitRightNoteAudio.Play();
            hitRightNoteAudio2.Play();
        }
    }

    public void HitSound()
    {
        if (hitNoteAudio != null)
        {
            hitNoteAudio.Play();
        }
    }

    public void BombSound()
    {
        if (bombSound != null)
        {
            bombSound.Play();
        }
    }

    public void ExplodeSound()
    {
        if (explodeSound != null)
        {
            explodeSound.Play();
        }
    }

    public void CritSound()
    {
        if (critSound != null)
        {
            critSound.Play();
        }
    }

    public void EnemyAttackSound()
    {
        if (enemyAttackAudio != null)
        {
            enemyAttackAudio.Play();
        }
    }

    public void SwingSound()
    {
        if (swingAudio != null)
        {
            swingAudio.Play();
        }
    }
    public void ThunderSound()
    {
        if (thunderAudio != null)
        {
            thunderAudio.Play();
        }
    }    
    public void IntroBombSound()
    {
        if (introBomb != null)
        {
            introBomb.Play();
        }
    }

    public void overDriveSound()
    {
        if (overDrive != null)
        {
            overDrive.Play();
        }
    }
}
