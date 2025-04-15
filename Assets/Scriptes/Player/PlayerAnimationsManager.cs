using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private MoveController moveController;

    [SerializeField]
    private GameObject[] particlePodoshva = new GameObject[2];

    //��������� ������ � ��� ����������
    [SerializeField]
    private GameObject player;
    private PlayerInfo playerInfo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        IniAnimatorParam();
        OnOffParticlePodoshva();
        Errors();
    }

    /// <summary>
    /// ���������� ���������� ���������
    /// </summary>
    private void IniAnimatorParam()
    {
        //��������� ������������
        if (!moveController.LockMove)
        {
            animator.SetBool("IsMoveLeft", moveController.IsMoveLeft);
            animator.SetBool("IsMoveRight", moveController.IsMoveRight);
            animator.SetBool("IsMoveIdle", moveController.IsMoveIdle);
        }
        //��������� ���������
        animator.SetBool("IsDead", playerInfo.IsDead);
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

    private void Errors()
    {
        if (animator == null)
        {
            Debug.LogError("����������� animator!");
        }
        if (moveController == null)
        {
            Debug.LogError("����������� moveController!");
        }
        if (particlePodoshva == null)
        {
            Debug.LogError("����������� particlePodoshva!");
        }
        else
        {
            if (particlePodoshva[0] == null)
            {
                Debug.LogError("����������� particlePodoshva[0]!");
            }
            if (particlePodoshva[1] == null)
            {
                Debug.LogError("����������� particlePodoshva[1]!");
            }
        }
        if (player == null)
        {
            Debug.LogError("����������� player!");
        }
        if (playerInfo == null)
        {
            Debug.LogError("����������� playerInfo!");
        }
    }
}
