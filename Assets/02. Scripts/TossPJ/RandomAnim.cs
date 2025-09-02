using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    private Animator animator;

    void OnEnable()
    {
        animator = GetComponent<Animator>();

        // 현재 상태 이름 가져오기
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 0 ~ 1 사이에서 랜덤한 시점에서 시작
        float randomTime = Random.Range(0f, 10f);

        // 현재 재생 중인 상태를 랜덤 시점에서 재생
        animator.Play(stateInfo.shortNameHash, 0, randomTime);
    }
}
