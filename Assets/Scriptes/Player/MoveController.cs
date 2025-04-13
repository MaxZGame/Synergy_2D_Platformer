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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInfo = GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        Errors();
        LeftAndRightMove();
        Jumping();
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
        if (rb != null && playerInfo != null)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.linearVelocity = new Vector2(-MoveX * playerInfo.MoveSpeed, rb.linearVelocity.y);
                isMoveLeft = true;
                isMoveRight = false;
                isMoveIdle = false;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.linearVelocity = new Vector2(MoveX * playerInfo.MoveSpeed, rb.linearVelocity.y);
                isMoveLeft = false;
                isMoveRight = true;
                isMoveIdle = false;
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                isMoveLeft = false;
                isMoveRight = false;
                isMoveIdle = true;
                Debug.Log("Персонаж остановился");
            }
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, playerInfo.ForceJump), ForceMode2D.Impulse);
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
