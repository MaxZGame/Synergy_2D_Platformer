using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private MoveController moveController;

    [SerializeField]
    private GameObject[] particlePodoshva = new GameObject[2];

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        IniAnimatorParam();
        OnOffParticlePodoshva();
    }

    /// <summary>
    /// Присвоение переменных аниматора
    /// </summary>
    private void IniAnimatorParam()
    {
        animator.SetBool("IsMoveLeft", moveController.IsMoveLeft);
        animator.SetBool("IsMoveRight", moveController.IsMoveRight);
        animator.SetBool("IsMoveIdle", moveController.IsMoveIdle);
    }

    private void OnOffParticlePodoshva()
    {
        if (moveController.IsMoveRight)
        {
            particlePodoshva[0].SetActive(true);
        }
        else
        {
            particlePodoshva[0].SetActive(false);
        }
        if (moveController.IsMoveLeft)
        {
            particlePodoshva[1].SetActive(true);
        }
        else
        {
            particlePodoshva[1].SetActive(false);
        }
    }
}
