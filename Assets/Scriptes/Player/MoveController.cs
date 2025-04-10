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
    /// ���������� ��� �������� ���������� �� �����
    /// </summary>
    private bool isGrounded = true;
    public bool IsGrounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    /// <summary>
    /// ��� �������� ������� ������
    /// </summary>
    private bool isJumping = false;
    public bool IsJumping
    {
        get { return isJumping; }
        set { isJumping = value; }
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
            isJumping = false;
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
        if (rb != null && playerInfo != null)
        {
            MoveX = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(moveX * playerInfo.MoveSpeed, rb.linearVelocity.y);
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, playerInfo.ForceJump), ForceMode2D.Impulse);
            IsJumping = true;
        }
    }

    private void Errors()
    {
        if (rb == null)
        {
            Debug.LogError("������! rb �� ������!");
        }
        if (playerInfo == null)
        {
            Debug.LogError("������! playerInfo �� ������!");
        }
    }
}
