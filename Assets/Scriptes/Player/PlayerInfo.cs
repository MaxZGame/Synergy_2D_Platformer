using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private string playerName = "Имя не задано";
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    [SerializeField]
    private int health = 100; //Жизни
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float moveSpeed = 5f;//Скорость ходьбы
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    [SerializeField]
    private float forceJump = 9f;//Сила прыжка
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
    private int money = 0;//Количество монет
    public int Money
    {
        get { return money; }
        set { money = value; }
    }
}
