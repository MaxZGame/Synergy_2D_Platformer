using UnityEngine;

public class MoveController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private Rigidbody2D rb;
    private float moveX;
    public float MoveX
    {
        get { return moveX; }
        set { moveX = value; }
    }

    /// <summary>
    /// Переменная для проверки нахождения на земле
    /// </summary>
    private bool isGrounded = true;
    public bool IsGrounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    //Ставим флаги на направление движения или стоячее положение
    private bool isMoveLeft = false;
    public bool IsMoveLeft
    {
        get { return isMoveLeft; }
        set { isMoveLeft = value; }
    }
    private bool isMoveRight = false;
    public bool IsMoveRight
    {
        get { return isMoveRight; }
        set { isMoveRight = value; }
    }
    private bool isMoveIdle = true;
    public bool IsMoveIdle
    {
        get { return isMoveIdle; }
        set { isMoveIdle = value; }
    }
    private bool isMoving = false;

    private bool lockMove = false; //Флаг на блокировку движения
    public bool LockMove
    {
        get { return lockMove; }
        set { lockMove = value; }
    }

    //Работа со звуками
    [SerializeField]
    private GameObject audioManagerObj;
    private AudioManager audioManager;
    [SerializeField]
    private float stepIntervalZvuk = 0.5f;
    [SerializeField]
    private float stepTimerZvuk = 0f;

    private bool isDeadZvuk = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInfo = GetComponent<PlayerInfo>();
        lockMove = false;
        audioManager = audioManagerObj.GetComponent<AudioManager>();
    }

    private void Update()
    {
        Errors();
        LeftAndRightMove();
        Jumping();
        UpdateMoveZvuk();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    private void LeftAndRightMove()
    {
        MoveX = 1f;
        if (rb != null && playerInfo != null && !playerInfo.IsDead && !lockMove && !audioManager.IsFinal)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.linearVelocity = new Vector2(-MoveX * playerInfo.MoveSpeed, rb.linearVelocity.y);
                isMoveLeft = true;
                isMoveRight = false;
                isMoveIdle = false;
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.linearVelocity = new Vector2(MoveX * playerInfo.MoveSpeed, rb.linearVelocity.y);
                isMoveLeft = false;
                isMoveRight = true;
                isMoveIdle = false;
                isMoving = true;
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                isMoveLeft = false;
                isMoveRight = false;
                isMoveIdle = true;
                isMoving = false;
            }
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !playerInfo.IsDead && !lockMove)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, playerInfo.ForceJump), ForceMode2D.Impulse);
            audioManager.PlayJumpSound();
            isMoving = false;
        }

    }

    private void UpdateMoveZvuk()
    {
        if (isMoving && IsGrounded && !lockMove)
        {
            stepTimerZvuk += Time.deltaTime;
            if (stepTimerZvuk >= stepIntervalZvuk)
            {
                audioManager.PlayMoveSound();
                stepTimerZvuk = 0f; // Сбрасываем таймер
            }
        }
        else
        {
            stepTimerZvuk = stepIntervalZvuk;
        }
        if (playerInfo.IsDead)
        {
            if (!isDeadZvuk)
            {
                audioManager.PlayDeadSound();
                isDeadZvuk = true;
            }
        }
    }

    private void Errors()
    {
        if (rb == null)
        {
            Debug.LogError("Ошибка! rb не найден!");
        }
        if (playerInfo == null)
        {
            Debug.LogError("Ошибка! playerInfo не найден!");
        }
    }
}
