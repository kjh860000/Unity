using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager;
    void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score1":
                score = 10;
                break;
            case "Score2":
                score = 20;
                break;
            case "Score3":
                score = 30;
                break;
        }

        pinballManager.totalScore += score;
        Debug.Log($"점수 : {score}");

/*        if (other.gameObject.CompareTag("Score1"))
        {
            pinballManager.totalScore += 10;
            Debug.Log("10점");
        }
        else if (other.gameObject.CompareTag("Score2"))
        {
            pinballManager.totalScore += 20;
            Debug.Log("20점");
        }
        else if (other.gameObject.CompareTag("Score3"))
        {
            pinballManager.totalScore += 30;
            Debug.Log("30점");
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Game Over");
            Debug.Log($"총 점수 : {pinballManager.totalScore}");
        }

    }
}
