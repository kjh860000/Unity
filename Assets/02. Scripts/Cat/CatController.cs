using UnityEngine;
using Cat;
using UnityEngine.Video;
public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public UIManager uiManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    public GameObject happyVideo;
    public GameObject sadVideo;

    Rigidbody2D CatRb;
    Animator catAnim;

    public float JumpPower = 10;
    public float limitPower = 9f;
    public int jumpCount = 0;

    void Start()
    {
        CatRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++; // 1¾¿ Áõ°¡
            soundManager.OnJumpSound();
            CatRb.AddForceY(JumpPower, ForceMode2D.Impulse);

            if (CatRb.linearVelocityY > limitPower)
                CatRb.linearVelocityY = limitPower;


        }
        var catRotation = transform.eulerAngles;
        catRotation.z = CatRb.linearVelocityY * 3f;
        transform.eulerAngles = catRotation;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            if (GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white);
                this.GetComponent<CircleCollider2D>().enabled = false;

                Invoke("HappyVideo", 5f);
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
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black);
            this.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("SadVideo", 5f);

        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }
    void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        uiManager.playUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }

    void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        uiManager.playUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }
}