using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisualInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;//����� ����� � �������� (�����)

    [SerializeField]
    private TextMeshProUGUI healthText;//����� �������� (�����)

    //���������� ������ ������ ��� ������� � PlayerInfo
    private GameObject player;
    private PlayerInfo playerInfo;

    //���������� ������������� ��������� ��������
    [SerializeField]
    private GameObject bonusActiveText;

    //���������� ������ ������� ���������
    [SerializeField]
    private GameObject synergyBonus;
    private TakeItem takeItem;

    //���� �� ������
    [SerializeField]
    private GameObject bochka_1;
    [SerializeField]
    private GameObject bochka_2;
    [SerializeField]
    private TextMeshProUGUI healthTextBochka_1;
    [SerializeField]
    private TextMeshProUGUI healthTextBochka_2;
    private Enemy enemy_1;
    private Enemy enemy_2;

    private void Start()
    {
        Activator();
    }

    private void Update()
    {
        Errors();
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = "" + playerInfo.Money;
        healthText.text = "" + playerInfo.Health;
        healthTextBochka_1.text = "" + enemy_1.Health;
        healthTextBochka_2.text = "" + enemy_2.Health;
        if (takeItem.IsBonusActive)
        {
            bonusActiveText.SetActive(true);
            //����� ��������� ������ �� ��������� ������
            bonusActiveText.transform.position = new Vector2(83, 2);
        }

    }

    /// <summary>
    /// ��� ��������� ������ �����, �� ��� ������ ���� � �� - ���������� ������� ����.
    /// </summary>
    private void Activator()
    {
        //���������� ������� � �� ����������
        player = GameObject.Find("PLAYER");
        playerInfo = player.GetComponent<PlayerInfo>();
        takeItem = synergyBonus.GetComponent<TakeItem>();
        enemy_1 = bochka_1.GetComponent<Enemy>();
        enemy_2 = bochka_2.GetComponent<Enemy>();

        if (bonusActiveText.activeSelf == true)
        {
            bonusActiveText.SetActive(false);
        }
    }

    private void Errors()
    {
        if (player == null)
        {
            Debug.LogError("������! ������ player �� ������!");
        }
        if (playerInfo == null)
        {
            Debug.LogError("������! ������ playerInfo �� ������!");
        }
        if (moneyText == null)
        {
            Debug.LogError("������! ������ moneyText �� ������!");
        }
        if (healthText == null)
        {
            Debug.LogError("������! ������ healthText �� ������!");
        }
        if (bonusActiveText == null)
        {
            Debug.LogError("������! ������ bonusActiveText �� ������!");
        }
        if (synergyBonus == null)
        {
            Debug.LogError("������! ������ synergyBonus �� ������!");
        }
        if (takeItem == null)
        {
            Debug.LogError("������! ������ takeItem �� ������!");
        }
        if (bochka_1 == null)
        {
            Debug.LogError("������! ������ bochka_1 �� ������!");
        }
        if (bochka_2 == null)
        {
            Debug.LogError("������! ������ bochka_2 �� ������!");
        }
        if (healthTextBochka_1 == null)
        {
            Debug.LogError("������! ������ healthTextBochka_1 �� ������!");
        }
        if (healthTextBochka_2 == null)
        {
            Debug.LogError("������! ������ healthTextBochka_2 �� ������!");
        }
        if (enemy_1 == null)
        {
            Debug.LogError("������! ������ enemy_1 �� ������!");
        }
        if (enemy_2 == null)
        {
            Debug.LogError("������! ������ enemy_2 �� ������!");
        }
    }
}
