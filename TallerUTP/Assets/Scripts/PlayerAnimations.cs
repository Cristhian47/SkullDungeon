using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAttack(bool isAttacking)
    {
        anim.SetBool("isAttacking", isAttacking);
    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
