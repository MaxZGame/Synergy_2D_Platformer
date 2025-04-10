using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private MoveController moveController;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        IniAnimatorParam();
    }

    /// <summary>
    /// Присвоение переменных аниматора
    /// </summary>
    private void IniAnimatorParam()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveController.MoveX));
        if (moveController.MoveX != 0)
        {
            animator.SetFloat("Direction", moveController.MoveX);
        }
        if (moveController.IsJumping)
        {
            animator.SetBool("IsJumping", true);
        }
        if (!moveController.IsJumping)
        {
            animator.SetBool("IsJumping", false);
        }
        if (moveController.IsGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }
        if (!moveController.IsGrounded)
        {
            animator.SetBool("IsGrounded", false);
        }
    }
}
