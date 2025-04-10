using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private GameObject player;
    private PlayerInfo playerInfo;
    private bool isBonusActive = false;
    public bool IsBonusActive
    {
        get {  return isBonusActive; }
    }

    private void Start()
    {
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
                    playerInfo.Money += 1;
                    Debug.Log("���������� �����: " + playerInfo.Money);
                }
            }
        }
        else if (this.gameObject.CompareTag("SynergyBonus"))
        {
            if (collision.CompareTag("Player"))
            {
                this.gameObject.SetActive (false);
                if (playerInfo != null)
                {
                    playerInfo.ForceJump *= playerInfo.BonusForceJump;
                    isBonusActive = true;
                    Debug.Log("����� ������ �����������");
                }
            }
        }
    }
}