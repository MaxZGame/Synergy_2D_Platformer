using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private GameObject player;
    private PlayerInfo playerInfo;
    private bool isBonusActive = false;
    public bool IsBonusActive
    {
        get { return isBonusActive; }
    }

    //���������� ����
    private GameObject audioManagerObj;
    private AudioManager audioManager;

    //��� �������� ������
    private GameObject moneyIcon;
    private AnimationsMoney animationsMoney;

    private void Start()
    {
        moneyIcon = GameObject.FindWithTag("UIMoney");
        animationsMoney = moneyIcon.GetComponent<AnimationsMoney>();

        audioManagerObj = GameObject.FindWithTag("AudioManager");
        audioManager = audioManagerObj.GetComponent<AudioManager>();
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInfo = player.GetComponent<PlayerInfo>();
            if (playerInfo == null)
            {
                Debug.LogError("PlayerInfo component not found on Player!");
            }
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������� ��� �������, �� ������� ����� ���� ������
        if (this.gameObject.CompareTag("Money"))
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                if (playerInfo != null)
                {
                    audioManager.PlayMoneyZvuk();
                    playerInfo.Money += 1;
                    animationsMoney.PlayTakeAnimation();
                    Debug.Log("���������� �����: " + playerInfo.Money);
                }
            }
        }
        else if (this.gameObject.CompareTag("SynergyBonus"))
        {
            if (collision.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
                if (playerInfo != null)
                {
                    playerInfo.ForceJump *= playerInfo.BonusForceJump;
                    isBonusActive = true;
                    audioManager.PlayBonusTake();
                    Debug.Log("����� ������ �����������");
                }
            }
        }
    }

    private void Update()
    {
        Errors();
    }

    private void Errors()
    {
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