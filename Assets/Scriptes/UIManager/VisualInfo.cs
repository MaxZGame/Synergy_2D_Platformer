using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisualInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;//����� ����� � �������� (�����)

    [SerializeField]
    private Slider healthPlayerSlider; //������� �������� ��� �������
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
        healthPlayerSlider.value = playerInfo.Health;
        healthText.text = "" + playerInfo.Health;
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

        //������ ��� � ���� �������� ��� ��������
        healthPlayerSlider.minValue = 0;
        healthPlayerSlider.maxValue = 100;

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
        if (healthPlayerSlider == null)
        {
            Debug.LogError("������! ������ healthPlayerSlider �� ������!");
        }
        if (moneyText == null)
        {
            Debug.LogError("������! ������ moneyText �� ������!");
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
    }
}
