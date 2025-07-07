using UnityEngine;
using Cat;
using UnityEngine.Video;
using System.Collections;
public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public UIManager uiManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    Rigidbody2D CatRb;
    Animator catAnim;

    public float JumpPower = 10;
    public float limitPower = 9f;
    public int jumpCount = 0;

    // 순서 Awake - OnEnable - Start
    void Awake()
    {
        CatRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void OnEnable() // 켜질때마다 1번씩 실행
    {
        transform.localPosition = new Vector3(-8f,0f,0f);
        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.mute = false;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++; // 1씩 증가
            soundManager.OnJumpSound();

            // y축 속도 초기화 후 점프력 부여
            Vector2 velocity = CatRb.linearVelocity;
            velocity.y = 0f;  // 이전 y속도 초기화 (누적 점프력 방지)
            CatRb.linearVelocity = velocity;

            CatRb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

            // 속도 제한
            if (CatRb.linearVelocity.y > limitPower)
            {
                Vector2 limitedVelocity = CatRb.linearVelocity;
                limitedVelocity.y = limitPower;
                CatRb.linearVelocity = limitedVelocity;
            }
        }
        var catRotation = transform.eulerAngles;
        catRotation.z = CatRb.linearVelocityY * 3f;
        transform.eulerAngles = catRotation;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        int scoreToAdd = 0;

        if (other.CompareTag("Apple")) scoreToAdd = 1;
        else if (other.CompareTag("GoldenApple")) scoreToAdd = 3;

        if (scoreToAdd > 0)
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score += scoreToAdd;

            if (GameManager.score >= 20)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false;

                StartCoroutine(EndingRoutine(true));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();

            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true);
            this.GetComponent<CircleCollider2D>().enabled = false;

            //Invoke("SadVideo", 3f);
            StartCoroutine(EndingRoutine(false));

        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }
/*    void HappyVideo()
    {
        videoManager.VideoPlay(true);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        uiManager.playUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }

    void SadVideo()
    {
        videoManager.VideoPlay(false);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        uiManager.playUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }*/

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);

        //uiManager.playObj.SetActive(false);

        soundManager.audioSource.mute = true;
        videoManager.VideoPlay(isHappy); // 영상 재생
        yield return new WaitForSeconds(1f);

        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadeRoutine>().OnFade(3f, newColor, false);
        //yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);

        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        //transform.parent.gameObject.SetActive(false); // PLAY off
        uiManager.playObj.SetActive(false);
    }
}