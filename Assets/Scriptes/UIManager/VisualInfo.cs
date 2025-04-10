using UnityEngine;
using TMPro;

public class VisualInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;

    //Подключаем объект игрока для доступа к PlayerInfo
    private GameObject player;
    private PlayerInfo playerInfo;

    private void Start()
    {
        player = GameObject.Find("PLAYER");
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = "" + playerInfo.Money;
    }
}
