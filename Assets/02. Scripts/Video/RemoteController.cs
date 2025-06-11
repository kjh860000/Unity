using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;
    private VideoPlayer videoPlayer;
    public VideoClip[] clips; // ���� ���� �迭

    public int currClipIndex = 0; // ���� ���� Index

    // public bool isOn = false;
    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0]; // Default ���� ����
    }

    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        // GameObject �Ӽ��� Ȱ���� ���
        videoScreen.SetActive(!videoScreen.activeSelf);

        // NOT�� Ȱ���Ͽ� �ٿ��� ���� ���
        // isOn = !isOn;
        // videoScreen.SetActive(isOn);

        // ��� ���� ���
        // if (!isOn) // isOn == false
        // {
        //     videoScreen.SetActive(true);
        //     isOn = true; // ���� Ƽ�� On
        // }
        // else // isOn == true
        // {
        //     videoScreen.SetActive(false);
        //     isOn = false;
        // }
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute); // ������ �Ҹ� ���Ұ�

        // ���� ������ Mute �Ӽ��� Ȱ���� ���
        videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    // public void OnChangeChannel(bool isNext)
    // {
    //     int value = isNext ? 1 : -1;
    //     currClipIndex += value;
    //
    //     if (currClipIndex > clips.Length - 1)
    //         currClipIndex = 0;
    //
    //     if (currClipIndex < 0)
    //         currClipIndex = clips.Length - 1;
    //
    //     videoPlayer.clip = clips[currClipIndex];
    //     videoPlayer.Play();
    // }

    public void OnNextChannel() // ������ ��ư
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // ���� ��ư
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}