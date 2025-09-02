using UnityEngine;

public class JudgeLine : MonoBehaviour
{
    public bool canJudged = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine"))
        {
            canJudged = true;
            //Debug.Log("Note in");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine"))
        {
            canJudged = false;
            //Debug.Log("Note out");
        }
    }
}
