using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private string playerName = "��� �� ������";
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    [SerializeField]
    private int health = 100; //�����
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float moveSpeed = 5f;//�������� ������
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    [SerializeField]
    private float forceJump = 9f;//���� ������
    public float ForceJump
    {
        get { return forceJump; }
        set { forceJump = value; }
    }
    [SerializeField]
    private float bonusForceJump = 1.5f;
    public float BonusForceJump
    {
        get { return bonusForceJump; }
        set { bonusForceJump = value; }
    }
    [SerializeField]
    private int money = 0;//���������� �����
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

    //��������� ������
    private bool isDead = false; //������� ��� ���
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    private void Start()
    {
        isDead = false;
        Money = 0;
    }
    private void Update()
    {
        CheckStatePlayer();
    }

    private void CheckStatePlayer()
    {
        if (Health <= 0)
        {
            IsDead = true;
            Health = 0;
        }
    }
}
