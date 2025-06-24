using UnityEngine;

public class FollowPos : MonoBehaviour
{
    public Transform followPos;
    void Update()
    {
        transform.position = followPos.position;
        transform.rotation = followPos.rotation;
    }
}
